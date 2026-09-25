using Microsoft.AspNetCore.Identity;
using HelpDeskWeb.Data;
using HelpDeskWeb.Models;


namespace HelpDeskWeb.Services
{
    public class SeedService
    {

        public static async Task SeedDatabase(IServiceProvider serviceProvide)
        {

            using var scope = serviceProvide.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedService>>();


            try
            {
                // Ensure the database is ready
                logger.LogInformation("Ensuring the database is created");
                await context.Database.EnsureCreatedAsync();

                // Add roles
                logger.LogInformation("Seeding roles.");
                await AddRolesAsync(roleManager, "Admin");
                await AddRolesAsync(roleManager, "User");

                // Add admin user
                logger.LogInformation("Seeding admin user.");
                var adminEmail = "admin@codehub.com";
                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {

                    var adminUser = new User
                    {
                        FullName = "Code Hub",
                        UserName = adminEmail,
                        NormalizedUserName = adminEmail.ToUpper(),
                        Email = adminEmail,
                        NormalizedEmail = adminEmail.ToUpper(),
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                    };


                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while seeding the database.");
                throw;
            }
        }

        private static async Task AddRolesAsync(RoleManager<IdentityRole> roleManager, string v)
        {
            throw new NotImplementedException();
        }
    }
}
