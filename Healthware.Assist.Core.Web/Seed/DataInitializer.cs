using System;
using Healthware.Shared;
using Microsoft.AspNetCore.Identity;

namespace Healthware.Assist.Core.Web.Seed
{
    public static class DataInitializer
    {
        public static void SeedData(RoleManager<Role> roleManager)
        {
            SeedRoles(roleManager);
        }

        
        public static void SeedRoles(RoleManager<Role> roleManager)
        {
            
            CreateRole(roleManager, Enum.GetName(typeof(RoleEnum), RoleEnum.Patient));
            CreateRole(roleManager, Enum.GetName(typeof(RoleEnum), RoleEnum.Advocate));

            void CreateRole(RoleManager<Role> roleManager, string roleName)
            {
                if (!roleManager.RoleExistsAsync
                    (roleName).GetAwaiter().GetResult())
                {
                    Role role = new Role()
                    {
                        RoleName = roleName
                    };
                    IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                }
            }
        }
    }
}
