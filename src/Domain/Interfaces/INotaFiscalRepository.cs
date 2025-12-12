using Domain.Entities;

namespace Domain.Interfaces;

public interface INotaFiscalRepository
{
    Task AddAsync(NotaFiscal entity);
    Task<IEnumerable<NotaFiscal>> GetAllAsync();
}
