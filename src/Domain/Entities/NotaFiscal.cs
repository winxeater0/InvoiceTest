using Domain.ValueObjects;

namespace Domain.Entities;

public class NotaFiscal
{
    public int Id { get; set; }
    public string Numero { get; private set; } = default!;
    public Cnpj CnpjPrestador { get; private set; } = default!;
    public Cnpj CnpjTomador { get; private set; } = default!;
    public DateTime DataEmissao { get; private set; }
    public string DescricaoServico { get; private set; } = default!;
    public decimal ValorTotal { get; private set; }

    public NotaFiscal(
        string numero,
        Cnpj cnpjPrestador,
        Cnpj cnpjTomador,
        DateTime dataEmissao,
        string descricaoServico,
        decimal valorTotal)
    {
        Numero = numero;
        CnpjPrestador = cnpjPrestador;
        CnpjTomador = cnpjTomador;
        DataEmissao = dataEmissao;
        DescricaoServico = descricaoServico;
        ValorTotal = valorTotal;
    }

    // EF Core constructor
    private NotaFiscal() { }
}
