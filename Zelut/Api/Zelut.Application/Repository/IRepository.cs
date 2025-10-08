using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Zelute.Application.Repository;
public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> AsQueryable();
    IQueryable<TEntity> GetDataBySqlQuery(string sql_query, object? parameters = null);
    Task<TEntity> Add(TEntity entity);
    Task AddRange(List<TEntity> entities);
    Task<Result> SaveChangesAsync();
}