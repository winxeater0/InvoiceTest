using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
public class ErrorController : ControllerBase
{
    [Route("/error")]
    [HttpGet]
    public IActionResult HandleError()
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

        return Problem(
            title: "Internal Server Error",
            detail: context?.Error.Message
        );
    }
}

