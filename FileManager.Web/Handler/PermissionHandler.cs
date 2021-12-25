using System.Collections.Generic;
using System.Threading.Tasks;
using FileManager.Application.Constants;
using FileManager.Application.Repository.Interfaces;
using FileManager.Web.Providers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FileManager.Web.Handler
{
    public class PermissionHandler
    {
        private const string LoginUrl = "/Account/Login";
        private const string RegisterUrl = "/Account/Register";
        private const string UnAuthorizedPageUrl = "/UnAuthorized/Index";

        private static readonly List<string> PathsToAvoid = new()
        {
            LoginUrl,
            RegisterUrl,
        };

        private readonly RequestDelegate _next;

        public PermissionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task HandlePermission(HttpContext context, ICurrentUserProvider userProvider,
            IPermissionRepository permissionRepository)
        {
            var currentRequestPath = context.Request.Path;
            var currentRequestMethod = context.Request.Method;
            var requestedActionName = context.GetRouteData().Values["action"];
            var currentUserId = userProvider.GetCurrentUserId();

            if (!PathsToAvoid.Contains(currentRequestPath) && currentUserId != null)
            {
                var permissions = await permissionRepository.GetItemAsync(x => x.UserId == currentUserId);

                if (!permissions.PermissionTypes.Contains(PermissionConstant.ViewPermission) &&
                    currentRequestMethod != "GET")
                {
                    context.Response.StatusCode = 403;
                    context.Response.Redirect(UnAuthorizedPageUrl);
                }

                if (permissions.PermissionTypes.Contains(PermissionConstant.EditPermission) &&
                    requestedActionName.Equals("Remove") || requestedActionName.Equals("Delete"))
                {
                    context.Response.StatusCode = 403;
                    context.Response.Redirect(UnAuthorizedPageUrl);
                }
            }

            await _next.Invoke(context);
        }
    }
}