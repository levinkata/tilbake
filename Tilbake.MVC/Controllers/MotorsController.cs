using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    [Authorize]
    public class MotorsController : Controller
    {
        private readonly IMotorService _motorService;
        private readonly IBodyTypeService _bodyTypeService;
        private readonly IDriverTypeService _driverTypeService;
        private readonly IMotorMakeService _motorMakeService;
        private readonly IMotorModelService _motorModelService;
        private readonly IMotorUseService _motorUseService;

        public MotorsController(IMotorService motorService,
                                IBodyTypeService bodyTypeService,
                                IDriverTypeService driverTypeService,
                                IMotorMakeService motorMakeService,
                                IMotorModelService motorModelService,
                                IMotorUseService motorUseService)
        {
            _motorService = motorService;
            _bodyTypeService = bodyTypeService;
            _driverTypeService = driverTypeService;
            _motorMakeService = motorMakeService;
            _motorModelService = motorModelService;
            _motorUseService = motorUseService;
        }

        // GET: Motors
        public async Task<IActionResult> Index()
        {

            return View(await _motorService.GetAllAsync());
        }

        // GET: Motors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _motorService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // GET: Motors/Create
        public async Task<IActionResult> Create(Guid portfolioClientId)
        {
            var bodyTypes = await _bodyTypeService.GetAllAsync();
            var driverTypes = await _driverTypeService.GetAllAsync();
            var motorMakes = await _motorMakeService.GetAllAsync();
            var motorMakeId = motorMakes.FirstOrDefault().Id;
            var motorModels = await _motorModelService.GetByMotorMakeIdAsync(motorMakeId);
            var motorUses = await _motorUseService.GetAllAsync();
            
            MotorSaveResource resource = new MotorSaveResource()
            {
                PortfolioClientId = portfolioClientId,
                BodyTypeList = new SelectList(bodyTypes, "Id", "Name"),
                DriverTypeList = new SelectList(driverTypes, "Id", "Name"),
                MotorMakeList = new SelectList(motorMakes, "Id", "Name"),
                MotorModelList = new SelectList(motorModels, "Id", "Name"),
                MotorUseList = new SelectList(motorUses, "Id", "Name")
            };
            return await Task.Run(() => View(resource)).ConfigureAwait(true);
        }

        // POST: Motors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MotorSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _motorService.AddAsync(resource);
                return RedirectToAction(nameof(Index), "PortfolioClient", new { resource.PortfolioClientId });
            }
            return View(resource);
        }

        // GET: Motors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _motorService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }
            return View(resource);
        }

        // POST: Motors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, MotorResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _motorService.UpdateAsync(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: Motors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _motorService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: Motors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _motorService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
