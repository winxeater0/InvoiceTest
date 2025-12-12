using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class NotaFiscalRepository : BaseRepository<NotaFiscal>, INotaFiscalRepository
{
    public NotaFiscalRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddAsync(NotaFiscal entity)
    {
        await _context.NotasFiscais.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<NotaFiscal>> GetAllAsync()
    {
        return await _context.NotasFiscais.AsNoTracking().ToListAsync();
    }
}
