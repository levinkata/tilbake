using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(Guid countryId)
        {
            CitySaveResource resource = new()
            {
                CountryId = countryId
            };
            return View(resource);
        }

        [HttpPost]
        public IActionResult Create(CitySaveResource resource)
        {
            if (ModelState.IsValid)
            {
                _cityService.Add(resource);
                return RedirectToAction(nameof(Index), new { countryId = resource.CountryId });
            }

            return View(resource);
        }

        [HttpGet]
        public async Task<IActionResult> GetCities(Guid countryId)
        {
            var resources = await _cityService.GetByCountryId(countryId);
            var cities = from m in resources
                              select new
                              {
                                  m.Id,
                                  m.Name
                              };

            return Json(cities);
        }
    }
}
