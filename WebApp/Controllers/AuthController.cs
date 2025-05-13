using System.Threading.Tasks;
using Business.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    public IActionResult Login()
    {
        ViewBag.ErrorMessage = "";
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Login(MemberLoginForm form, string returnUrl = "~/")
    {
        ViewBag.ErrorMessage = "";

        if (ModelState.IsValid)
        {
            var result = await _authService.LoginAsync(form);
            if (result)
                return Redirect(returnUrl);
        }

        ViewBag.ErrorMessage = "Incorrect email or password";
        return View(form);
    }

    [AllowAnonymous]
    public IActionResult SignUp()
    {
        ViewBag.ErrorMessage = null;
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> SignUp(MemberSignUpForm form)
    {
        if (ModelState.IsValid)
        {
            var result = await _authService.SignUpAsync(form);
            if (result)
                return LocalRedirect("~/");
        }

        ViewBag.ErrorMessage = "There was an error during registration. Please try again.";
        return View(form);
    }

    public async Task<IActionResult> Logout()
    {
       await _authService.LogoutAsync();
        return LocalRedirect("~/");
    }

}
