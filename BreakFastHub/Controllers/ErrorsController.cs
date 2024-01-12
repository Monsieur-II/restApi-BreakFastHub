using Microsoft.AspNetCore.Mvc;

namespace BreakFastHub.Controllers;

[Route("/error")]
public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}
