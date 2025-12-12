using Application.Interfaces;
using Application.Mapping;
using Application.UseCases;
using Domain.Services;
using Infrastructure.Context;
using Infrastructure.Extensions;
using Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using Presentation.Xml;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Logging
builder.Host.UseSerilog((ctx, lc) =>
{
    lc.WriteTo.Console()
      .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day);
});

// Configuration
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAutoMapper(typeof(NotaFiscalProfile));
builder.Services.AddScoped<NotaFiscalXmlParser>();
builder.Services.AddScoped<INotaFiscalService, ImportarNotaFiscalUseCase>();
builder.Services.AddScoped<NotaFiscalDomainService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HealthChecks
builder.Services.AddHealthChecks()
    .AddDbContextCheck<AppDbContext>();

var app = builder.Build();

// Apply migrations and seed
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await context.Database.MigrateAsync();
    await DbSeeder.SeedAsync(context);
}

// Middleware global de erros
app.UseExceptionHandler("/error");

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// HealthCheck endpoint
app.MapHealthChecks("/health");

await app.RunAsync();
