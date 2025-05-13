using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Authorize]
public class ProjectsController : Controller
{
    public IActionResult Projects()
    {
        return View();
    }
}