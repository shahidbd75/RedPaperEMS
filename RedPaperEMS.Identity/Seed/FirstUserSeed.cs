using Microsoft.AspNetCore.Identity;
using RedPaperEMS.Identity.Models;
using System.Threading.Tasks;

namespace RedPaperEMS.Identity.Seed
{
    public class FirstUserSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var applicationUser = new ApplicationUser
            {
                FirstName = "Shahid",
                LastName = "AB",
                UserName = "shahid",
                Email = "shahid20@yahoo.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(applicationUser.Email);

            if (user == null)
            {
                await userManager.CreateAsync(applicationUser, "admin123");
            }
        }
    }
}
