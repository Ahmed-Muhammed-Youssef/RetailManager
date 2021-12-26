using DataManager.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DataManager.Areas.Identity
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<RetailUser>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<RetailUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(RetailUser user)
        {
            var claims = await base.GenerateClaimsAsync(user);
            claims.AddClaim(new Claim("FullName", user.FullName));
            return claims;
        }
    }
}
