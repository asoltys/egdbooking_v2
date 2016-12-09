using egdbooking_v2.Data;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using egdbooking_v2.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace src.Data
{
    public class SeedData
    {
        public static String[] ROLES = {
            "Admin", "User"
        };

        public async static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var users = context.Users.ToList();
            var egdUsers = context.EGDUsers.ToList();

            var userRoleMap =
                (from user in users
                join egdUser in egdUsers on user.Email equals egdUser.Email
                select new {
                    Id = user.Id,
                    Role = egdUser.Role
                }).ToList();

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            int dbRoleCount = 0;
            foreach (String role in ROLES)
            {
                // this blocks the loop, even though the method is async 
                var roleExists = await roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    var newRole = new IdentityRole();
                    newRole.Name = role;
                    await roleManager.CreateAsync(newRole);
                    await roleManager.AddClaimAsync(newRole, new Claim(ClaimTypes.Role, newRole.Name));
                } else
                {
                    dbRoleCount++;
                    continue;
                }
            }

            if (dbRoleCount >= 2)
            {
                return;
            }

            foreach (var userRole in userRoleMap)
            {
                var user = await userManager.FindByIdAsync(userRole.Id);
                var isInRole = await userManager.IsInRoleAsync(user, userRole.Role);
                if (!isInRole)
                {
                    await userManager.AddToRoleAsync(user, userRole.Role);
                }
            }
        }
    }
}
