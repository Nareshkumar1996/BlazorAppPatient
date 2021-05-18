using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Healthware.Assist.Core.Security;
using Healthware.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Healthware.Assist.Core.Web.Authorization
{
    public class CoreUserClaimsPrincipalFactory <TUser, TRole> : UserClaimsPrincipalFactory<TUser, TRole>
        where TUser : User
        where TRole : Role, new()
    {
        public CoreUserClaimsPrincipalFactory(UserManager<TUser> user, RoleManager<TRole> role,
            IOptions<IdentityOptions> optionsAccessor)
            : base((UserManager<TUser>) user, (RoleManager<TRole>) role, optionsAccessor)
        {
        }
        
        public override async Task<ClaimsPrincipal> CreateAsync(TUser user)
        {
            ClaimsPrincipal async = await base.CreateAsync(user);
           //if (user.Id.HasValue)
                async.Identities.First<ClaimsIdentity>().AddClaim(new Claim(UserClaimTypes.UserName, user.EmailAddress.ToString()));
            return async;
        }
    }
}
