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
    public class InsurerBranchesController : BaseController
    {
        public InsurerBranchesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.InsurerBranches.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<InsurerBranch>, IEnumerable<InsurerBranchViewModel>>(result);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetInsurerBranches(Guid insurerId)
        {
            var result = await _unitOfWork.InsurerBranches.GetByInsurerId(insurerId);
            var model = _mapper.Map<IEnumerable<InsurerBranch>, IEnumerable<InsurerBranchViewModel>>(result);

            var insurerBranches = from m in model
                               select new
                               {
                                   m.Id,
                                   m.Name
                               };

            return Json(insurerBranches);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsurerBranchViewModel model)
        {
            if(ModelState.IsValid)
            {
                var insurerBranch = _mapper.Map<InsurerBranchViewModel, InsurerBranch>(model);
                insurerBranch.Id = Guid.NewGuid();
                insurerBranch.DateAdded = DateTime.Now;

                await _unitOfWork.InsurerBranches.Add(insurerBranch);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.InsurerBranches.GetById(id);

            var model = _mapper.Map<InsurerBranch, InsurerBranchViewModel>(result);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.InsurerBranches.GetById(id);

            var model = _mapper.Map<InsurerBranch, InsurerBranchViewModel>(result);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, InsurerBranchViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                var insurerBranch = _mapper.Map<InsurerBranchViewModel, InsurerBranch>(model);
                insurerBranch.DateModified = DateTime.Now;

                await _unitOfWork.InsurerBranches.Update(insurerBranch);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.InsurerBranches.GetById(id);

            var model = _mapper.Map<InsurerBranch, InsurerBranchViewModel>(result);            
            return View(model);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.InsurerBranches.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}