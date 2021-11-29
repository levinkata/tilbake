using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    [Authorize]
    public class PoliciesController : BaseController
    {
        public PoliciesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        public async Task<IActionResult> Index(Guid portfolioClientId)
        {
            var result = await _unitOfWork.Policies.GetByPorfolioClientId(portfolioClientId);
            var model = _mapper.Map<IEnumerable<Policy>, IEnumerable<PolicyViewModel>>(result);
            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.Policies.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<Policy, PolicyViewModel>(result);
            return View(model);
        }
    }
}
