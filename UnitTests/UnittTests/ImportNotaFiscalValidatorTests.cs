using System;
using Application.DTOs;
using Application.Validators;
using FluentAssertions;
using Xunit;

namespace Tests.UnitTests;

public class ImportNotaFiscalValidatorTests
{
    private readonly ImportNotaFiscalValidator _validator;

    public ImportNotaFiscalValidatorTests()
    {
        _validator = new ImportNotaFiscalValidator();
    }

    [Fact]
    public void Validate_ValidDto_ShouldPass()
    {
        var dto = new ImportNotaFiscalDto(
            "123",
            "12345678000199",
            "98765432000188",
            DateTime.UtcNow,
            "Descrição",
            100.0m
        );

        var result = _validator.Validate(dto);

        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Validate_InvalidCnpj_ShouldFail()
    {
        var dto = new ImportNotaFiscalDto(
            "123",
            "111",
            "222",
            DateTime.UtcNow,
            "Descrição",
            100.0m
        );

        var result = _validator.Validate(dto);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle(e => e.PropertyName == "CnpjPrestador");
    }
}
