using Microsoft.Data.SqlClient;
using System;

public class LoginService
{
    private readonly SqlConnection _connection;

    public LoginService(SqlConnection connection)
    {
        _connection = connection;
    }

    public int ExecuteLoginProcedure(string username, string password)
    {
        int responseCode = 0;

        using (var cmd = new SqlCommand("procLogin", _connection))
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    responseCode = Convert.ToInt32(dr["ResponseCode"]);
                }
            }
        }

        return responseCode;
    }
}
