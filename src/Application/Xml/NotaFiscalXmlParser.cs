using System.Globalization;
using System.Xml.Linq;
using Domain.Aggregates;
using Domain.Entities;

namespace Presentation.Xml;

public class NotaFiscalXmlParser
{

    public NotaFiscal Parse(string xml)
    {
        var doc = XDocument.Parse(xml);

        string numero = doc.Root?.Element("Numero")?.Value ?? string.Empty;
        string cnpjPrestador = doc.Root?.Element("Prestador")?.Element("CNPJ")?.Value ?? string.Empty;
        string cnpjTomador = doc.Root?.Element("Tomador")?.Element("CNPJ")?.Value ?? string.Empty;
        string descricao = doc.Root?.Element("Servico")?.Element("Descricao")?.Value ?? string.Empty;
        string valor = doc.Root?.Element("Servico")?.Element("Valor")?.Value ?? "0";
        string data = doc.Root?.Element("DataEmissao")?.Value ?? "0001-01-01";

        var aggregate = new NotaFiscalAggregate(
            numero,
            cnpjPrestador,
            cnpjTomador,
            DateTime.Parse(data),
            descricao,
            decimal.Parse(valor, CultureInfo.InvariantCulture)
        );

        return aggregate.NotaFiscal;
    }
}
