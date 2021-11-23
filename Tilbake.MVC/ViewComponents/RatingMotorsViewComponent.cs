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
            ViewBag.InsurerId = insurerId;
            var ViewModels = await _ratingMotorService.GetByInsurerAsync(insurerId);
            return View(ViewModels);
        }
    }
}
