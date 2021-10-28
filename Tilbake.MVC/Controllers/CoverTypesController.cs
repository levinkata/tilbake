using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    public class CoverTypesController : Controller
    {
        private readonly ICoverTypeService _coverTypeService;

        public CoverTypesController(ICoverTypeService coverTypeService)
        {
            _coverTypeService = coverTypeService;
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
        public IActionResult Create(CoverTypeSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                _coverTypeService.Add(resource);
                return RedirectToAction(nameof(Index));
            }

            return View(resource);
        }

        [HttpGet]
        public async Task<IActionResult> GetCoverTypes()
        {
            var resources = await _coverTypeService.GetAllAsync();
            var coverTypes = from m in resources
                              select new
                              {
                                  m.Id,
                                  m.Name
                              };

            return Json(coverTypes);
        }
    }
}
