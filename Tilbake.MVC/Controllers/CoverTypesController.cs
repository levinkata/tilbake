using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

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
        public IActionResult Create(CoverTypeViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                _coverTypeService.AddAsync(ViewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(ViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetCoverTypes()
        {
            var ViewModels = await _coverTypeService.GetAllAsync();
            var coverTypes = from m in ViewModels
                              select new
                              {
                                  m.Id,
                                  m.Name
                              };

            return Json(coverTypes);
        }
    }
}
