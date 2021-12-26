using Microsoft.Extensions.Configuration;

namespace FileManager.Application.Extensions;

public static class ConnectionConfigurationExtension
{
    /// <summary>
    ///     Use Default Connection string
    /// </summary>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static string GetDefaultConnectionString(this IConfiguration configuration)
    {
        return configuration.GetConnectionString("DefaultConnection");
    }
}