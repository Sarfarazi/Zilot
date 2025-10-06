using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Zelut.Common.Helpers;

namespace Zelut.Infrastructure.Repository;

public class DapperHelper : IDapperHelper
{
    public async Task<IEnumerable<T>> RunAsync<T>(string connectionString, string sql_query, object parameters)
    {
        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            var result = await connection.QueryAsync<T>(sql_query, parameters);
            return result;
        }
    }

    public async Task<IEnumerable<T>> RunAsync<T>(string connectionString, string sql_query)
    {
        using(IDbConnection connection = new SqlConnection(connectionString))
        {
            var result = await connection.QueryAsync<T>(sql_query);
            return result;
        }
    }

    public async Task<IEnumerable<T>> RunAsync<T>(string connectionString,string sql, SqlBuilder sqlBuilder)
    {
        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            var template = sqlBuilder.AddTemplate(sql);
            var result = await connection.QueryAsync<T>(template.RawSql, template.Parameters);
            return result;
        }
    }
}