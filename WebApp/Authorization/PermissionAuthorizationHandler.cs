using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WebApp.Authorization
{
    public class PermissionAuthorizationHandler
        : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            PermissionRequirement requirement)
        {
            // Verifica se o usuário tem a claim de permissão
            var hasPermission = context.User.HasClaim("Permission", requirement.Permission);

            if (hasPermission)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
