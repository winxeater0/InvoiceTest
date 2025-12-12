namespace Application.DTOs;

public record ImportNotaFiscalDto(
    string Numero,
    string CnpjPrestador,
    string CnpjTomador,
    DateTime DataEmissao,
    string DescricaoServico,
    decimal ValorTotal
);
