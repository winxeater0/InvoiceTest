using Infrastructure.Context;
using Domain.Aggregates;

namespace Infrastructure.Seed;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!context.NotasFiscais.Any())
        {
            var nota = new NotaFiscalAggregate(
                "9999",
                "11111111000111",
                "22222222000122",
                DateTime.UtcNow,
                "Nota fiscal de seed",
                199.90m
            ).NotaFiscal;

            await context.NotasFiscais.AddAsync(nota);
            await context.SaveChangesAsync();
        }
    }
}
