using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OrganicDesignPatterns.Domain.Common;
using OrganicDesignPatterns.Domain.Interfaces;
using OrganicDesignPatterns.Persistence.Context;

namespace OrganicDesignPatterns.Persistence.Repositories;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly OrganicDesignPatternsDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(OrganicDesignPatternsDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
    {
        return await _dbSet.Where(filter).ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> filter)
    {
        return await _dbSet.FirstOrDefaultAsync(filter);
    }

    public async Task AddAsync(T entity)
    {
        entity.CreatedDate = DateTime.Now;
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        entity.UpdatedDate = DateTime.Now;
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        entity.IsDeleted = true;
        entity.UpdatedDate = DateTime.Now;
        _dbSet.Update(entity);
    }

    public IQueryable<T> GetQueryable()
    {
        return _dbSet.AsQueryable();
    }
}