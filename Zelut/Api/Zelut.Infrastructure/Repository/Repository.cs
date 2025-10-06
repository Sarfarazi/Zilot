using Microsoft.EntityFrameworkCore;
using Zelute.Application.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    #region Fields
    private readonly ZelutDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;
    #endregion

    #region ctor
    public Repository(ZelutDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }
    #endregion

    #region  Methods
    public async Task<TEntity> Add(TEntity entity)
    {
        var entity_entry = await _dbSet.AddAsync(entity);
        return (TEntity) entity_entry.Entity;
    }

    public async Task AddRange(List<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public async Task<bool> SaveChangesAsync()
    {
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    #endregion
}