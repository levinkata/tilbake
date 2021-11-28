using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class UserPortfoliosController : BaseController
    {
        public UserPortfoliosController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

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
            var unAssignedPortfolios = await _unitOfWork.UserPortfolios.GetByNotUserId(userId);
            var userPortfolios = await _unitOfWork.UserPortfolios.GetByUserId(userId);
            var assignedPortfolios = userPortfolios.Select(r => new
                                                    {
                                                        r.Id,
                                                        r.Name
                                                    });

            return Json(new { unAssignedPortfolios, assignedPortfolios });
        }

        [HttpPost]
        public IActionResult AddUserPortfolios(string userId, Guid[] portfolioIds)
        {
            List<AspnetUserPortfolio> aspnetUserPortfolios = new();

            var aspNetUserId = userId;

            foreach (var portfolioId in portfolioIds)
            {
                AspnetUserPortfolio aspnetUserPortfolio = new()
                {
                    AspNetUserId = aspNetUserId,
                    PortfolioId = Guid.Parse(portfolioId.ToString())
                };
                aspnetUserPortfolios.Add(aspnetUserPortfolio);
            }

            _unitOfWork.UserPortfolios.AddRange(aspnetUserPortfolios);
            _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(FillMultiSelectLists), new { userId });
        }

        [HttpPost]
        public IActionResult RemoveUserPortfolios(string userId, Guid[] portfolioIds)
        {
            List<AspnetUserPortfolio> aspnetUserPortfolios = new();

            var aspNetUserId = userId;

            foreach (var portfolioId in portfolioIds)
            {
                AspnetUserPortfolio aspnetUserPortfolio = new()
                {
                    AspNetUserId = aspNetUserId,
                    PortfolioId = Guid.Parse(portfolioId.ToString())
                };
                aspnetUserPortfolios.Add(aspnetUserPortfolio);
            }

            _unitOfWork.UserPortfolios.DeleteRange(aspnetUserPortfolios);
            _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(FillMultiSelectLists), new { userId });
        }
    }
}
