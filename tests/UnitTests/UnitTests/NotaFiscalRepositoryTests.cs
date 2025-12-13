using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests.UnitTests;

public class NotaFiscalRepositoryTests
{
    private readonly NotaFiscalRepository _repository;
    private readonly AppDbContext _context;

    public NotaFiscalRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new AppDbContext(options);
        _repository = new NotaFiscalRepository(_context);
    }

    [Fact]
    public async Task AddAsync_ShouldAddNota()
    {
        var nota = new NotaFiscal(
            "999",
            new Cnpj("12345678000199"),
            new Cnpj("98765432000188"),
            DateTime.UtcNow,
            "Teste repo",
            100m
        );

        await _repository.AddAsync(nota);
        var allNotas = await _repository.GetAllAsync();

        allNotas.Should().ContainSingle();
        allNotas.First().Numero.Should().Be("999");
    }
}
