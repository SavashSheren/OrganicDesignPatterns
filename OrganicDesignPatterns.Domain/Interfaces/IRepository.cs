using System.Linq.Expressions;
using OrganicDesignPatterns.Domain.Common;

namespace OrganicDesignPatterns.Domain.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAllAsync();

    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);

    Task<T?> GetByIdAsync(int id);

    Task<T?> GetAsync(Expression<Func<T, bool>> filter);

    Task AddAsync(T entity);

    void Update(T entity);

    void Delete(T entity);

    IQueryable<T> GetQueryable();
}