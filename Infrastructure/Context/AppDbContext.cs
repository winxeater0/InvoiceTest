using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Context;

public class AppDbContext : DbContext
{
    public DbSet<NotaFiscal> NotasFiscais => Set<NotaFiscal>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var cnpjConverter = new ValueConverter<Cnpj, string>(
            v => v.Value,
            v => new Cnpj(v)
        );

        modelBuilder.Entity<NotaFiscal>(entity =>
        {
            entity.ToTable("NotasFiscais");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Numero)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(x => x.CnpjPrestador)
                .HasConversion(cnpjConverter)
                .IsRequired();

            entity.Property(x => x.CnpjTomador)
                .HasConversion(cnpjConverter)
                .IsRequired();

            entity.Property(x => x.DescricaoServico)
                .HasMaxLength(500)
                .IsRequired();

            entity.Property(x => x.ValorTotal)
                .HasColumnType("decimal(18,2)");
        });
    }
}
