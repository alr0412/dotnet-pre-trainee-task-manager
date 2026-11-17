using Microsoft.Data.SqlClient;

class SqlConnectionFactory : IDbConnectionFactory
{
    private readonly string ConnectingString;
    public SqlConnectionFactory(string connectingString)
    {
        ConnectingString = connectingString;
    }
    public async Task<SqlConnection> CreateConnectionAsync()
    {
        var connection = new SqlConnection(ConnectingString);
        await connection.OpenAsync();
        return connection;
    }
}