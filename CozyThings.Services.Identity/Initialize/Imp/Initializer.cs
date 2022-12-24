using CozyThings.Services.Identity.Data;
using CozyThings.Services.Identity.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CozyThings.Services.Identity.Initialize.Imp
{
    public class Initializer : IInitializer
    {
        private readonly AppDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public Initializer(
            AppDbContext dbContext, 
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void Initialize()
        {
            if (roleManager.FindByNameAsync(StaticDetails.ADMIN).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(StaticDetails.ADMIN)).GetAwaiter().GetResult();
                roleManager.CreateAsync(new IdentityRole(StaticDetails.CUSTOMER)).GetAwaiter().GetResult();
            }
            else { return; }

            ApplicationUser adminUser = new()
            {
                UserName = "admin1",
                Email = "admin1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+380934343333",
                FirstName = "Alan",
                LastName = "Norman"
            };

            userManager.CreateAsync(adminUser, "admin1").GetAwaiter().GetResult();
            userManager.AddToRoleAsync(adminUser, StaticDetails.ADMIN).GetAwaiter().GetResult();

            var admin1 = userManager.AddClaimsAsync(adminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, adminUser.FirstName + " " + adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName, adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, adminUser.LastName),
                new Claim(JwtClaimTypes.Role, StaticDetails.ADMIN)
            }).Result;

            ApplicationUser customerUser = new()
            {
                UserName = "customer1",
                Email = "customer1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+380934343388",
                FirstName = "Alex",
                LastName = "Petrov"
            };

            userManager.CreateAsync(customerUser, "customer1").GetAwaiter().GetResult();
            userManager.AddToRoleAsync(customerUser, StaticDetails.CUSTOMER).GetAwaiter().GetResult();

            var customer1 = userManager.AddClaimsAsync(customerUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, customerUser.FirstName + " " + customerUser.LastName),
                new Claim(JwtClaimTypes.GivenName, customerUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, customerUser.LastName),
                new Claim(JwtClaimTypes.Role, StaticDetails.CUSTOMER)
            }).Result;
        }
    }
}
