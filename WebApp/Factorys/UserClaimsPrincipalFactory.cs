using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

public class CustomUserClaimsPrincipalFactory
    : UserClaimsPrincipalFactory<MemberEntity>
{
    public CustomUserClaimsPrincipalFactory(
        UserManager<MemberEntity> userManager,
        IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, optionsAccessor) { }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(MemberEntity user)
    {
        var identity = await base.GenerateClaimsAsync(user);

        identity.AddClaim(new Claim(ClaimTypes.GivenName, user.FirstName ?? ""));
        identity.AddClaim(new Claim(ClaimTypes.Surname, user.LastName ?? ""));

        return identity;
    }
}
