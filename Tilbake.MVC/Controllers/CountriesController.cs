using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CountrySaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _countryService.AddAsync(resource);
                return RedirectToAction(nameof(Index));
            }

            return View(resource);
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var resources = await _countryService.GetAllAsync();
            var countries = from m in resources
                              select new
                              {
                                  m.Id,
                                  m.Name
                              };

            return Json(countries);
        }
    }
}
