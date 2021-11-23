using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class InsurersController : BaseController
    {
        public InsurersController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Insurers.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<Insurer>, IEnumerable<InsurerViewModel>>(result);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetInsurers()
        {
            var result = await _unitOfWork.Insurers.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<Insurer>, IEnumerable<InsurerViewModel>>(result);

            var insurers = from m in model
                            select new
                            {
                                m.Id,
                                m.Name
                            };

            return Json(insurers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsurerViewModel model)
        {
            if(ModelState.IsValid)
            {
                var insurer = _mapper.Map<InsurerViewModel, Insurer>(model);
                insurer.Id = Guid.NewGuid();
                insurer.DateAdded = DateTime.Now;

                await _unitOfWork.Insurers.Add(insurer);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.Insurers.GetById(id);

            var model = _mapper.Map<Insurer, InsurerViewModel>(result);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.Insurers.GetById(id);

            var model = _mapper.Map<Insurer, InsurerViewModel>(result);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, InsurerViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                var insurer = _mapper.Map<InsurerViewModel, Insurer>(model);
                insurer.DateModified = DateTime.Now;

                await _unitOfWork.Insurers.Update(insurer);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.Insurers.GetById(id);

            var model = _mapper.Map<Insurer, InsurerViewModel>(result);            
            return View(model);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.Insurers.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}