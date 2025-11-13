using Dapper;
using Microsoft.AspNetCore.Connections;
using System.Data;

namespace SMSService.Api.Dapper
{
    public static class DaperExtensions
    {
        public static async Task DapperQuery(this ISqlConnectionFactory _connectionFactory,
            string sql,object sqlParams=null,
            CommandType commandType=CommandType.StoredProcedure)
        {
            using var connection = _connectionFactory.CreateConnection();
           var res=  await connection.ExecuteAsync(sql.ToString(), param: sqlParams, commandType: commandType);
            if (res == 0) {
                throw new Exception($"Dapper Command Executed {sql } was  Failed");
            }

        }
        public static async Task<IEnumerable<T>> DapperQuery<T>(this ISqlConnectionFactory _connectionFactory,
        string sql, object sqlParams = null,
        CommandType commandType = CommandType.StoredProcedure)
        {
            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryAsync<T>(sql, param: sqlParams, commandType: commandType);
            

        }
    }
}
