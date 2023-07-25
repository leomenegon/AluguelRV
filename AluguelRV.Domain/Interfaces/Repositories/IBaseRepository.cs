using System.Linq.Expressions;

namespace AluguelRV.Domain.Interfaces.Repositories;
public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> Create(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    Task<TEntity> GetById(dynamic id);
    void Detach(TEntity entity);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
    Task Delete(TEntity entity);
    void Dispose();
}