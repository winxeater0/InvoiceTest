using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public abstract class BaseRepository<T> where T : class
{
    protected readonly AppDbContext _context;

    protected BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    protected IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return _context.Set<T>().Where(spec.Criteria);
    }
}
