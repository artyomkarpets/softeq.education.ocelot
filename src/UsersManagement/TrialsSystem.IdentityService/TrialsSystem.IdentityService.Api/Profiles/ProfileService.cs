using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using TrialsSystem.IdentityService.Domain.AggregatesModel.ApplicationUserAggregate;

namespace TrialsSystem.IdentityService.Api.Profiles
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var id = context.Subject.FindFirst(JwtClaimTypes.Subject);
            var user = await _userManager.FindByIdAsync(id.Value);
            var roles = await _userManager.GetRolesAsync(user);
            var roleNames = string.Join(",", roles);
            context.IssuedClaims.Add(new System.Security.Claims.Claim("roles", roleNames));
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.CompletedTask;
        }
    }
}
