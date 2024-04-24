using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManager.Services.Exceptions;

namespace UserManager.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var exception = context?.Error;

        var notFound = exception as NotFoundException;
        if (notFound != null)
        {
            return Problem(
                title: "Entity not found",
                detail: exception.Message,
                statusCode: StatusCodes.Status404NotFound);
        }

        return Problem(detail: context?.Error?.StackTrace, title: context?.Error?.Message);
    }
}
