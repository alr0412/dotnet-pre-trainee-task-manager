using Microsoft.Data.SqlClient;

public interface IDbConnectionFactory
{
    public Task<SqlConnection> CreateConnectionAsync();
}