using Microsoft.AspNetCore.Mvc;

namespace FileManager.Web.Extensions;

public static class ApiControllerExtension
{
    public static IActionResult SendSuccess(this Controller controller, string notify, object data = null)
    {
        return controller.Ok(new
        {
            notify, data
        });
    }

    public static IActionResult SendError(this Controller controller, string error)
    {
        return controller.BadRequest(new
        {
            error = new
            {
                message = error
            }
        });
    }
}