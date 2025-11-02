using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
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
    public async Task<TEntity?> GetAsync(Expression<Func<TEntity,bool>> predicate)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(predicate);
        return entity;
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
                Message = "اطلاعات با موفقیت ثبت نشد، لطفا دوباره تلاش کنید."
            };
        }
    }
    #endregion
}