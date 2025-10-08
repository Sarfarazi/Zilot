using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Zelute.Application.Repository;

public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    #region Fields
    private readonly ZelutDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;
    #endregion

    #region ctor
    public EfRepository(ZelutDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }
    #endregion

    #region  Methods
    public IQueryable<TEntity> AsQueryable()
    {
        return _dbSet.AsQueryable();
    }
    public DbSet<TEntity> GetDbSet()
    {
        return _dbSet;
    }
    public async Task<TEntity> Add(TEntity entity)
    {
        var entity_entry = await _dbSet.AddAsync(entity);
        return (TEntity) entity_entry.Entity;
    }
    public IQueryable<TEntity> GetDataBySqlQuery(string sql_query, object? parameters = null)
    {
        if(parameters is not null)
        {
            return _dbSet.FromSqlRaw(sql_query, parameters);
        }

        return _dbSet.FromSqlRaw(sql_query);
    }
    public async Task AddRange(List<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }
    public async Task<Result> SaveChangesAsync()
    {
        try
        {
            await _dbContext.SaveChangesAsync();
            return new Result
            {
                IsSuccess= true,
                Message = string.Empty,
            };
        }

        catch (Exception ex)
        {
            return new Result
            {
                IsSuccess = false,
                Message = "???? ??? ???????."
            };
        }
    }
    #endregion
}