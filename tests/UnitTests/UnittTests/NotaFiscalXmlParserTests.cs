using System;
using Presentation.Xml;
using FluentAssertions;
using Xunit;

namespace Tests.UnitTests;

public class NotaFiscalXmlParserTests
{
    private readonly NotaFiscalXmlParser _parser;

    public NotaFiscalXmlParserTests()
    {
        _parser = new NotaFiscalXmlParser();
    }

    [Fact]
    public void Parse_ValidXml_ShouldReturnNotaFiscal()
    {
        string xml = @"
        <NotaFiscal>
            <Numero>12345</Numero>
            <Prestador>
                <CNPJ>12345678000199</CNPJ>
            </Prestador>
            <Tomador>
                <CNPJ>98765432000188</CNPJ>
            </Tomador>
            <DataEmissao>2024-12-10</DataEmissao>
            <Servico>
                <Descricao>Teste de serviço</Descricao>
                <Valor>1500.00</Valor>
            </Servico>
        </NotaFiscal>";

        var nota = _parser.Parse(xml);

        nota.Should().NotBeNull();
        nota.Numero.Should().Be("12345");
        nota.CnpjPrestador.Value.Should().Be("12345678000199");
        nota.CnpjTomador.Value.Should().Be("98765432000188");
        nota.DescricaoServico.Should().Be("Teste de serviço");
        nota.ValorTotal.Should().Be(1500.00m);
    }

    [Fact]
    public void Parse_InvalidXml_ShouldThrow()
    {
        string invalidXml = "<NotaFiscal></NotaFiscal>";

        Action act = () => _parser.Parse(invalidXml);

        act.Should().Throw<FormatException>();
    }
}
