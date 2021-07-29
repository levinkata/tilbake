using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.MVC.Areas.Identity;

namespace Tilbake.MVC.Controllers
{
    public class UserPortfoliosController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserPortfolioService _userPortfolioService;

        public UserPortfoliosController(UserManager<ApplicationUser> userManager,
                    IUserPortfolioService userPortfolioService)
        {
            _userManager = userManager;
            _userPortfolioService = userPortfolioService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            UserPortfolioResource resource = new UserPortfolioResource()
            {
                Users = new SelectList(users, "Id", "Email"),
            };

            return await Task.Run(() => View(resource));
        }

        [HttpGet]
        public async Task<IActionResult> FillMultiSelectLists(string userId)
        {
            var unAssignedPortfolios = await _userPortfolioService.GetByNotUserIdAsync(userId);

            var userPortfolios = await _userPortfolioService.GetByUserIdAsync(userId);
            var assignedPortfolios = userPortfolios.Select(r => new
                                                    {
                                                        Id = r.Id,
                                                        Name = r.Name
                                                    });

            return Json(new { unAssignedPortfolios, assignedPortfolios });
        }

        [HttpPost]
        public async Task<IActionResult> AddUserPortfolios(string userId, string[] portfolios)
        {
            UserPortfolioResource resource = new UserPortfolioResource()
            {
                UserId = userId,
                PortfolioIds = portfolios
            };

            await _userPortfolioService.AddRangeAsync(resource);

            return RedirectToAction(nameof(FillMultiSelectLists), new { userId });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUserPortfolios(string userId, string[] portfolios)
        {
            UserPortfolioResource resource = new UserPortfolioResource()
            {
                UserId = userId,
                PortfolioIds = portfolios
            };

            await _userPortfolioService.DeleteRangeAsync(resource);

            return RedirectToAction(nameof(FillMultiSelectLists), new { userId });
        }
    }
}
