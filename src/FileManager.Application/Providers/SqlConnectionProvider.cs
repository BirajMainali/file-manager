using FileManager.Application.Extensions;
using FileManager.Application.Providers.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace FileManager.Application.Providers;

public class SqlConnectionProvider : ISqlConnectionProvider
{
    private readonly IConfiguration _configuration;

    public SqlConnectionProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    ///     Ready to use NpgsqlConnection
    /// </summary>
    /// <returns></returns>
    public NpgsqlConnection GetConnection()
    {
        var connectionString = _configuration.GetDefaultConnectionString();
        return new NpgsqlConnection(connectionString);
    }
}