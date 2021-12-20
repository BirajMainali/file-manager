using FileManager.Application.Extensions;
using Microsoft.Extensions.Configuration;
using Npgsql;
using ISqlConnectionProvider = FileManager.Application.Providers.Interfaces.ISqlConnectionProvider;

namespace FileManager.Application.Providers
{
    public class SqlConnectionProvider : ISqlConnectionProvider
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionProvider(IConfiguration configuration)
            => _configuration = configuration;

        /// <summary>
        /// Ready to use NpgsqlConnection
        /// </summary>
        /// <returns></returns>
        public NpgsqlConnection GetConnection()
        {
            var connectionString = _configuration.GetDefaultConnectionString();
            return new NpgsqlConnection(connectionString);
        }
    }
}
