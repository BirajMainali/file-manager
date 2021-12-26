using FileManager.Web.Handler;
using Microsoft.AspNetCore.Builder;

namespace FileManager.Web.Middleware
{
    public static class AuthorizationMiddleware
    {
        public static IApplicationBuilder UseUserAuthorization(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PermissionHandler>();
        }
    }
}