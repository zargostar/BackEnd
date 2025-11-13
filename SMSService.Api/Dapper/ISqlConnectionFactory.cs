using Microsoft.Data.SqlClient;
using System.Data;

namespace SMSService.Api.Dapper
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
