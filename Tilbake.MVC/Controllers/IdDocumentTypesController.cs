using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    [Authorize]
    public class IdDocumentTypesController : Controller
    {
        private readonly IIdDocumentTypeService _idDocumentTypeService;

        public IdDocumentTypesController(IIdDocumentTypeService idDocumentTypeService)
        {
            _idDocumentTypeService = idDocumentTypeService;
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
        public async Task<IActionResult> Create(IdDocumentTypeSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _idDocumentTypeService.AddAsync(resource);
                return RedirectToAction(nameof(Index));
            }

            return View(resource);
        }

        [HttpGet]
        public async Task<IActionResult> GetIdDocumentTypes()
        {
            var resources = await _idDocumentTypeService.GetAllAsync();
            var idDocumentTypes = from m in resources
                              select new
                              {
                                  m.Id,
                                  m.Name
                              };

            return Json(idDocumentTypes);
        }

        [HttpGet]
        public async Task<IActionResult> GetIdDocumentType(Guid id)
        {
            var resource = await _idDocumentTypeService.GetByIdAsync(id);

            return Json(new { resource.Id, resource.Name});
        }
    }
}
