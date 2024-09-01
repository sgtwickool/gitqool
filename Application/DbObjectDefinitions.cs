using Dapper;
using Microsoft.Data.SqlClient;

namespace gitqool.Application;

public class DbObjectDefinitions
{
    public string Name { get; set; }
    public string? SchemaName { get; set; }
    public string TypeDesc { get; set; }
    public string Definition { get; set; }
}