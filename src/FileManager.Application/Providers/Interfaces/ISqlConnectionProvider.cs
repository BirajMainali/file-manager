using Npgsql;

namespace FileManager.Application.Providers.Interfaces
{
    public interface ISqlConnectionProvider
    {
        NpgsqlConnection GetConnection();
    }
}