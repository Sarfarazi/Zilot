using Dapper;

namespace Zelut.Common.Helpers;

public interface IDapperHelper
{
    Task<IEnumerable<T>> RunAsync<T>(string connectionString, string sql_query, object parameters);
    Task<IEnumerable<T>> RunAsync<T>(string connectionString, string sql_query);
    Task<IEnumerable<T>> RunAsync<T>(string connectionString, string sql, SqlBuilder sqlBuilder);
}