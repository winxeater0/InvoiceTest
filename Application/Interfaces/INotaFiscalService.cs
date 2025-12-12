using Application.Common;
using Application.DTOs;

namespace Application.Interfaces;

public interface INotaFiscalService
{
    Task<Result<bool>> ImportarXmlAsync(string xmlContent);
    Task<Result<IEnumerable<NotaFiscalDto>>> ObterNotasAsync();
}
