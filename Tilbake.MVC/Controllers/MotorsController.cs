using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Core;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Helpers;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    [Authorize]
    public class MotorsController : BaseController
    {
        public MotorsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: Motors
        public async Task<IActionResult> Index()
        {

            var result = await _unitOfWork.Motors.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<Motor>, IEnumerable<MotorViewModel>>(result);
            return View(model);
        }

        // GET: Motors/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.Motors.GetById(id);
            var model = _mapper.Map<Motor, MotorViewModel>(result);
            return View(model);
        }

        // GET: Motors/Create
        public async Task<IActionResult> Create(Guid portfolioClientId)
        {
            var bodyTypes = await _unitOfWork.BodyTypes.GetAll(r => r.OrderBy(n => n.Name));
            var driverTypes = await _unitOfWork.DriverTypes.GetAll(r => r.OrderBy(n => n.Name));
            var motorMakes = await _unitOfWork.MotorMakes.GetAll(r => r.OrderBy(n => n.Name));
            var motorMakeId = motorMakes.FirstOrDefault().Id;
            var motorModels = await _unitOfWork.MotorModels.GetByMotorMakeId(motorMakeId);
            
            MotorViewModel model = new()
            {
                PortfolioClientId = portfolioClientId,
                BodyTypeList = MVCHelperExtensions.ToSelectList(bodyTypes, Guid.Empty),
                DriverTypeList = MVCHelperExtensions.ToSelectList(driverTypes, Guid.Empty),
                MotorMakeList = MVCHelperExtensions.ToSelectList(motorMakes, Guid.Empty),
                MotorModelList = MVCHelperExtensions.ToSelectList(motorModels, Guid.Empty),
            };
            return View(model);
        }

        // POST: Motors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MotorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var motor = _mapper.Map<MotorViewModel, Motor>(model);
                motor.Id = Guid.NewGuid();
                motor.DateAdded = DateTime.Now;

                await _unitOfWork.Motors.Add(motor);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index), "PortfolioClient", new { model.PortfolioClientId });
            }
            return View(model);
        }

        // GET: Motors/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.Motors.GetById(id);
            var model = _mapper.Map<Motor, MotorViewModel>(result);
            return View(model);
        }

        // POST: Motors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, MotorViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var motor = _mapper.Map<MotorViewModel, Motor>(model);
                motor.DateModified = DateTime.Now;

                await _unitOfWork.Motors.Update(motor);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.Motors.GetById(id);
            var model = _mapper.Map<Motor, MotorViewModel>(result);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.Motors.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
