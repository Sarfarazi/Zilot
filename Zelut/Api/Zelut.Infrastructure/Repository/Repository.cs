using Microsoft.EntityFrameworkCore;
using Zelute.Application.Repository;

public class Repository<TEntity> : IRepository<TEntity>
{
    #region Fields
    private readonly ZelutDbContext _dbContext;
    #endregion

    #region ctor
    public Repository(DbContext dbContext)
    {
        _dbContext = _dbContext;
    }
    #endregion

    #region  Methods
    public async Task<TEntity> Add(TEntity entity)
    {
        var entity_entry = await _dbContext.AddAsync(entity);
        return (TEntity) entity_entry.Entity;
    }

    public async Task AddRange(List<TEntity> entities)
    {
        await _dbContext.AddRangeAsync(entities);
    }

    public async Task<bool> SaveChangesAsync()
    {
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    #endregion
}