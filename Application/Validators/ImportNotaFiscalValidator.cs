using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class ImportNotaFiscalValidator : AbstractValidator<ImportNotaFiscalDto>
{
    public ImportNotaFiscalValidator()
    {
        RuleFor(x => x.Numero)
            .NotEmpty().WithMessage("Número é obrigatório");

        RuleFor(x => x.CnpjPrestador)
            .NotEmpty().Matches(@"^\d{14}$").WithMessage("CNPJ do prestador inválido.");

        RuleFor(x => x.CnpjTomador)
            .NotEmpty().Matches(@"^\d{14}$").WithMessage("CNPJ do tomador inválido.");

        RuleFor(x => x.DataEmissao)
            .LessThan(DateTime.UtcNow.AddDays(1))
            .WithMessage("Data de emissão inválida.");

        RuleFor(x => x.ValorTotal)
            .GreaterThan(0)
            .WithMessage("Valor total deve ser maior que zero.");
    }
}
