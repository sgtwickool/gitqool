using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace gitqool.Application;

public class DbObjectDefinitionsRepo {
    public async Task GetAllAsync<IDbObjectDefinitionsRepository>(string servername, string database, string username, string password)
    {
        string connectionString = $"Driver=SQL Server;SERVER={servername};DATABASE={database};UID={username};PWD={password}";

        var connection = new SqlConnection(connectionString);
        var sql = "SELECT name FROM sys.databases";
        var customers = await connection.QueryAsync(sql);
        
        foreach(var customer in customers)
        {
            Console.WriteLine($"{customer.CustomerID} {customer.CompanyName}");
        }
    }
}