using CondoLounge.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace CondoLounge.Data
{
    public class CondoSeeder
    {
        private readonly ApplicationDbContext _db;  // Reference to the database context so we can insert data
        private readonly IWebHostEnvironment _hosting; // Gives access to the project's folder paths
        private readonly UserManager<ApplicationUser> _userManager; // Manages creating users, checking passwords, assigning roles
        private readonly RoleManager<IdentityRole<int>> _roleManager; // Manages creating and checking Identity roles

        // Constructor receives dependencies through Dependency Injection
        public CondoSeeder(
            ApplicationDbContext context,
            IWebHostEnvironment hosting,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<int>> roleManager)
        {
            _db = context;
            _hosting = hosting;     //will be used to find the full path of the project 
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            //Verify that the database exists. Hover over the method and read the documentation. 
            _db.Database.EnsureCreated();

            // -----------------------------
            // 1. Create roles if none exist
            // -----------------------------
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole<int>("Admin"));
                await _roleManager.CreateAsync(new IdentityRole<int>("Default"));
            }

            // Seed some data with an Admin user that is part of an initial<br/>
            //  Building, Condo and the
            //Default and Admin roles available.

            Building building;
            if (!_db.Buildings.Any())
            {
                building = new Building
                {
                    Name = "Main Building",
                    BuildingId = 12
                };
                _db.Buildings.Add(building);
                await _db.SaveChangesAsync();
            }
            else { building = _db.Buildings.First(); }

            // ---------------------------------------
            // 3. Create a default admin user (if none)
            // ---------------------------------------
            if (!_userManager.Users.Any())
            {
                // Create a user object
                var user = new ApplicationUser()
                {
                    UserName = "admin",
                    Email = "admin@email.com",
                    BuildingId = building.BuildingId,
                };

                await _userManager.CreateAsync(user, "VerySecureAdmin45%");
                await _userManager.AddToRoleAsync(user, "Admin");
            }
        }

    }
}
