using Microsoft.AspNetCore.Identity;

namespace WebApp.Data
{
    public static class DbInitializer
    {
        public static async Task SeedUsersAndRolesAsync(IServiceProvider service)
        {
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = service.GetRequiredService<UserManager<IdentityUser>>();

            // Criar Role Admin se não existir
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));

            // Criar usuário admin
            var admin = await userManager.FindByEmailAsync("admin@admin.com");

            if (admin == null)
            {
                admin = new IdentityUser()
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(admin, "Admin123");

                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
