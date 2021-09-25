using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;

namespace Tilbake.MVC.ViewComponents
{
    [Authorize]
    public class RatingMotorsViewComponent : ViewComponent
    {
        private readonly IRatingMotorService _ratingMotorService;
        private readonly IInsurerService _insurerService;

        public RatingMotorsViewComponent(IRatingMotorService ratingMotorService,
                                        IInsurerService insurerService)
        {
            _ratingMotorService = ratingMotorService;
            _insurerService = insurerService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid insurerId)
        {
            var insurer = await _insurerService.GetByIdAsync(insurerId);
            ViewBag.InsurerId = insurerId;
            ViewBag.InsurerName = insurer.Name;
            var resources = await _ratingMotorService.GetByInsurerAsync(insurerId);
            return View(resources);
        }
    }
}
