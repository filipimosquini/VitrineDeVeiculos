using Backend.Api.Bases;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("healthcheck")]
public class healthcheckController : MainController
{

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return CustomResponse("Ok");
    }
}