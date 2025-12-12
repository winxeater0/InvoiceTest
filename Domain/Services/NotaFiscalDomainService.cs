using Domain.Entities;
using Domain.Exceptions;
using Domain.Validators;

namespace Domain.Services;

public class NotaFiscalDomainService : IDomainService<NotaFiscal>
{
    public void Validate(NotaFiscal entity)
    {
        var validator = new NotaFiscalValidator();
        var result = validator.Validate(entity);

        if (!result.IsValid)
            throw new DomainValidationException(string.Join("; ", result.Errors.Select(e => e.ErrorMessage)));
    }
}
