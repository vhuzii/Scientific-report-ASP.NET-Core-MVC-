using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ScientificReport.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientificReport.Models
{
    public class RolesInitializer
    {
        public static async Task InitializeAsync(ReportContext context, IServiceProvider service)
        {
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
            var roleNames = new[] { "Admin", "FacultyAdmin", "DepartmentAdmin" , "Teacher"};
            IdentityResult roleResult;
            foreach(var roleName in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}
