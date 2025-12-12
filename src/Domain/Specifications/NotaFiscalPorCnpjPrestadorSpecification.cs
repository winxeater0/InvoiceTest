using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using System.Linq.Expressions;

namespace Domain.Specifications;

public class NotaFiscalPorCnpjPrestadorSpecification : ISpecification<NotaFiscal>
{
    private readonly Cnpj _cnpj;

    public NotaFiscalPorCnpjPrestadorSpecification(Cnpj cnpj)
    {
        _cnpj = cnpj;
    }

    public Expression<Func<NotaFiscal, bool>> Criteria =>
        nf => nf.CnpjPrestador.Value == _cnpj.Value;
}
