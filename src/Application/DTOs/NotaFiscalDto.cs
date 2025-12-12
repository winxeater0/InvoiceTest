namespace Application.DTOs;

public record NotaFiscalDto(
    int Id,
    string Numero,
    string CnpjPrestador,
    string CnpjTomador,
    DateTime DataEmissao,
    string DescricaoServico,
    decimal ValorTotal
);
