using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure.DatabaseContext;

public class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _connection;

    public DapperDbContext(IConfiguration configuration)
    {   
        _configuration = configuration;

        string connectionString =
            _configuration.GetConnectionString("PostgresConnection")!;
        connectionString = connectionString.Replace("$POSTGRES_USER", Environment.GetEnvironmentVariable("POSTGRES_USER"))
            .Replace("$POSTGRES_PASSWORD", Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")).Replace("$POSTGRES_HOST", Environment.GetEnvironmentVariable("POSTGRES_HOST")).Replace("$POSTGRES_DB", Environment.GetEnvironmentVariable("POSTGRES_DB")).Replace("$POSTGRES_PORT", Environment.GetEnvironmentVariable("POSTGRES_PORT"));

        _connection = new NpgsqlConnection(connectionString);
    }

    public IDbConnection DbConnection => _connection;
} 