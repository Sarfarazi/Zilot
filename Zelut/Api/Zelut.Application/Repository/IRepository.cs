namespace Zelute.Application.Repository;
public interface IRepository<TEntity>
{
    Task<TEntity> Add(TEntity entity);
    Task AddRange(List<TEntity> entities);
    Task<bool> SaveChangesAsync();
}