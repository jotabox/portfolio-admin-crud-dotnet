using System.Security.Claims;

namespace WebApp.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool HasPermission(this ClaimsPrincipal user, string permission)
        {
            return user.HasClaim("Permission", permission);
        }
    }
}
