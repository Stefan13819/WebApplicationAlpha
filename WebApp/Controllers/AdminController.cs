
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;



[Route("admin")]
[Authorize]
public class AdminController : Controller
{
    [Route("members")]
    public IActionResult Members()
    {
        return View();

    }

    [Route("clients")]
    public IActionResult Clients()
    {
        return View();

    }


}