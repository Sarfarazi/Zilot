using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Zelute.Application.Repository;
public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
    IQueryable<TEntity> AsQueryable();
    IQueryable<TEntity> GetDataBySqlQuery(string sql_query, object? parameters = null);
    Task<TEntity> Add(TEntity entity);
    Task AddRange(List<TEntity> entities);
    Task<Result> SaveChangesAsync();
}