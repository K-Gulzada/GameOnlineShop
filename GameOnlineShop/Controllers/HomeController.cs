using GameOnlineShop.Data.Models;
using GameOnlineShop.Services;
using GameShop.Data.Interfaces;
using GameShop.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        public HomeController(RoleManager<IdentityRole> roleManager = null, UserManager<User> userManager = null)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            AddDefaultRolesAndAdmin defaultRoles = new AddDefaultRolesAndAdmin(_roleManager, _userManager);
            await defaultRoles.CreateRoles();
            await defaultRoles.AddAdmin();
            return View();
        }
    }
}
