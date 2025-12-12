using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

public class NotaFiscalValidator : AbstractValidator<NotaFiscal>
{
    public NotaFiscalValidator()
    {
        RuleFor(x => x.Numero)
            .NotEmpty().WithMessage("Número da nota é obrigatório.");

        RuleFor(x => x.DescricaoServico)
            .NotEmpty().WithMessage("Descrição do serviço é obrigatória.");

        RuleFor(x => x.ValorTotal)
            .GreaterThan(0).WithMessage("Valor total deve ser maior que zero.");

        RuleFor(x => x.DataEmissao)
            .NotEmpty().WithMessage("Data de emissão inválida.");
    }
}
