using System.Data;
using Microsoft.Data.SqlClient;
using no.sanddata.ams.Application.Abstractions.Data;

namespace no.sanddata.ams.Infrastructure.Data;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public IDbConnection CreateConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();

        return connection;
    } 
}
