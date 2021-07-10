using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Tilbake.MVC.Controllers
{
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var roles = roleManager.Roles.ToList();
            return await Task.Run(() => View(roles)).ConfigureAwait(true);
        }

        [Authorize(Policy = "CreateRole")]
        public async Task<IActionResult> Create()
        {
            return await Task.Run(() => View(new IdentityRole())).ConfigureAwait(true);
        }

        [HttpPost]
        [Authorize(Policy = "CreateRole")]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction(nameof(Index));
        }
    }
}
