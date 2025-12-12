using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public class NotaFiscalAggregate
{
    public NotaFiscal NotaFiscal { get; }

    public NotaFiscalAggregate(
        string numero,
        string cnpjPrestador,
        string cnpjTomador,
        DateTime dataEmissao,
        string descricao,
        decimal valor)
    {
        NotaFiscal = new NotaFiscal(
            numero,
            new Cnpj(cnpjPrestador),
            new Cnpj(cnpjTomador),
            dataEmissao,
            descricao,
            valor
        );
    }
}
