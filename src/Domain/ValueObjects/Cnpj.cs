using Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects;

public class Cnpj
{
    public string Value { get; private set; } = default!;

    public Cnpj(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainValidationException("CNPJ não pode ser vazio.");

        if (!Regex.IsMatch(value, @"^\d{14}$"))
            throw new DomainValidationException("CNPJ deve conter 14 dígitos.");

        Value = value;
    }

    private Cnpj() { }

    public override string ToString() => Value;

    public override bool Equals(object? obj) =>
        obj is Cnpj other && Value == other.Value;

    public override int GetHashCode() => Value.GetHashCode();
}
