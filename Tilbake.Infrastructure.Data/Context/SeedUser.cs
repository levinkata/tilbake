using Microsoft.AspNetCore.Identity;
using System;
using System.Globalization;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Data.Context
{
    public static class SeedUser
    {
        public static void Seed(UserManager<ApplicationUser> userManager,
                                RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        //  Create Startup Users
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager == null)
            {
                throw new ArgumentNullException(nameof(userManager));
            };

            if (userManager.FindByNameAsync("levi.nkata@outlook.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "levi.nkata@outlook.com",
                    Email = "levi.nkata@outlook.com",
                    PhoneNumber = "72107147",
                    ConcurrencyStamp = DateTime.Now.ToString(CultureInfo.CurrentCulture)
                };

                string userPWD = "Susan@0570";
                IdentityResult result = userManager.CreateAsync(user, userPWD).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }

            if (userManager.FindByNameAsync("naledi.nkata@outlook.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "naledi.nkata@outlook.com",
                    Email = "naledi.nkata@outlook.com",
                    PhoneNumber = "72107148",
                    ConcurrencyStamp = DateTime.Now.ToString(CultureInfo.CurrentCulture)
                };

                string userPWD = "Naledi@2907";
                IdentityResult result = userManager.CreateAsync(user, userPWD).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "NormalUser").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (roleManager == null)
            {
                throw new ArgumentNullException(nameof(roleManager));
            };

            if (!roleManager.RoleExistsAsync("NormalUser").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "NormalUser"
                };
                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Administrator"
                };
                roleManager.CreateAsync(role).Wait();
            }
        }
    }
}
