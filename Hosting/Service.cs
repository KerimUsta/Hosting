using Microsoft.Data.SqlClient;

public class DatabaseContext : IDisposable
{
    private readonly SqlConnection _connection;  //SqlConnection türünde bir _connection tanımlanır.

    public DatabaseContext(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
        _connection.Open();
    }

    public SqlConnection GetConnection()
    {
        return _connection;
    }

    public void Dispose()
    {
        _connection.Close();
    }
}

