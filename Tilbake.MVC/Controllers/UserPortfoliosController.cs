using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        private readonly IPortfolioService _portfolioService;
        private readonly IUserPortfolioService _userPortfolioService;

        public UserPortfoliosController(UserManager<ApplicationUser> userManager,
                    IPortfolioService portfolioService,
                    IUserPortfolioService userPortfolioService)
        {
            _userManager = userManager;
            _portfolioService = portfolioService;
            _userPortfolioService = userPortfolioService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            UserPortfolioResource resource = new UserPortfolioResource()
            {
                Users = new SelectList(users, "Id", "Email"),
            };

            return await Task.Run(() => View(resource)).ConfigureAwait(true);
        }

        [HttpGet]
        public async Task<IActionResult> FillMultiSelectLists(string userId)
        {
            var unAssignedPortfolios = await _portfolioService.GetByNotUserIdAsync(userId).ConfigureAwait(true);

            var userPortfolios = await _userPortfolioService.GetByUserIdAsync(userId).ConfigureAwait(true);
            var assignedPortfolios = userPortfolios.Select(r => new
                                                    {
                                                        Id = r.PortfolioId,
                                                        Name = r.PortfolioName
                                                    });

            return Json(new { unAssignedPortfolios, assignedPortfolios });
        }

        [HttpPost]
        public async Task<IActionResult> AddUserPortfolios(string userId, string[] portfolios)
        {
            UserPortfolioResource resource = new UserPortfolioResource()
            {
                UserId = userId,
                Portfolios = portfolios
            };

            await _userPortfolioService.AddRangeAsync(resource).ConfigureAwait(true);

            return RedirectToAction(nameof(FillMultiSelectLists), new { userId });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUserPortfolios(string userId, string[] portfolios)
        {
            UserPortfolioResource resource = new UserPortfolioResource()
            {
                UserId = userId,
                Portfolios = portfolios
            };

            await _userPortfolioService.DeleteRangeAsync(resource).ConfigureAwait(true);

            return RedirectToAction(nameof(FillMultiSelectLists), new { userId });
        }
    }
}
