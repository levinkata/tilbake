using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;
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

            UserPortfolioViewModel ViewModel = new()
            {
                Users = new SelectList(users, "Id", "Email"),
            };

            return View(ViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> FillMultiSelectLists(string userId)
        {
            var unAssignedPortfolios = await _userPortfolioService.GetByNotUserIdAsync(userId);

            var userPortfolios = await _userPortfolioService.GetByUserIdAsync(userId);
            var assignedPortfolios = userPortfolios.Select(r => new
                                                    {
                                                        r.Id,
                                                        r.Name
                                                    });

            return Json(new { unAssignedPortfolios, assignedPortfolios });
        }

        [HttpPost]
        public IActionResult AddUserPortfolios(string userId, string[] portfolios)
        {
            UserPortfolioViewModel ViewModel = new()
            {
                UserId = userId,
                PortfolioIds = portfolios
            };

            _userPortfolioService.AddRange(ViewModel);

            return RedirectToAction(nameof(FillMultiSelectLists), new { userId });
        }

        [HttpPost]
        public IActionResult RemoveUserPortfolios(string userId, string[] portfolios)
        {
            UserPortfolioViewModel ViewModel = new()
            {
                UserId = userId,
                PortfolioIds = portfolios
            };

            _userPortfolioService.DeleteRange(ViewModel);

            return RedirectToAction(nameof(FillMultiSelectLists), new { userId });
        }
    }
}
