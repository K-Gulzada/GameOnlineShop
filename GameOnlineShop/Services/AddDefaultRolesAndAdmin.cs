using GameOnlineShop.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace GameOnlineShop.Services
{
    public class AddDefaultRolesAndAdmin
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public AddDefaultRolesAndAdmin(RoleManager<IdentityRole> roleManager, UserManager<User> userManager = null)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task CreateRoles()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));
                await _roleManager.CreateAsync(new IdentityRole("manager"));
                await _roleManager.CreateAsync(new IdentityRole("user"));
            }
        }

        public async Task AddAdmin()
        {
            if (!_userManager.Users.Any())
            {
                User user = new User { Email = "admin@gmail.com", UserName = "admin" };

                await _userManager.CreateAsync(user, "admin");
                await _userManager.AddToRoleAsync(user, "admin");
            }
        }
    }
}
