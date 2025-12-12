namespace Domain.Services;

public interface IDomainService<T>
{
    void Validate(T entity);
}
