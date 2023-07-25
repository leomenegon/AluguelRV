using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AluguelRV.Repository.DbAccess;
using AluguelRV.Domain.Interfaces.Repositories;

namespace AluguelRV.Repository.Data;
public class Repository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly AluguelContext _dbContext;


    public Repository(AluguelContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<TEntity> Create(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity> Update(TEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicado)
    {
        return _dbContext.Set<TEntity>().Where(predicado).AsEnumerable();
    }

    public virtual async Task<TEntity> GetById(dynamic id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>().AsEnumerable();
    }

    public async Task Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public IDbContextTransaction InitializeTransaction()
    {
        return _dbContext.Database.BeginTransaction();
    }

    public void Detach(TEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Detached;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}