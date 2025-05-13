using Data.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Business.Services;

public interface IAuthService
{
    Task<bool> LoginAsync(MemberLoginForm loginForm);
    Task LogoutAsync();
    Task<bool> SignUpAsync(MemberSignUpForm signUpForm);
}

public class AuthService(SignInManager<MemberEntity> signInManager, UserManager<MemberEntity> userManager) : IAuthService
{
    private readonly SignInManager<MemberEntity> _signInManager = signInManager;
    private readonly UserManager<MemberEntity> _userManager = userManager;
    public async Task<bool> LoginAsync(MemberLoginForm loginForm)
    {
        var result = await _signInManager.PasswordSignInAsync(loginForm.Email, loginForm.Password,false, false);
        
        return result.Succeeded;
    }

    public async Task<bool> SignUpAsync(MemberSignUpForm signUpForm)
    {
        var MemberEntity = new MemberEntity
        {
            FirstName = signUpForm.FirstName,
            LastName = signUpForm.LastName,
            Email = signUpForm.Email,
            UserName = signUpForm.Email,
            PhoneNumber = signUpForm.PhoneNumber,

        };



        var result = await _userManager.CreateAsync(MemberEntity, signUpForm.Password);
        return result.Succeeded;
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }

}


