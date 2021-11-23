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
    public class BankBranchesController : BaseController
    {
        public BankBranchesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.BankBranches.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<BankBranch>, IEnumerable<BankBranchViewModel>>(result);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetBankBranches(Guid bankId)
        {
            var result = await _unitOfWork.BankBranches.GetByBankId(bankId);
            var model = _mapper.Map<IEnumerable<BankBranch>, IEnumerable<BankBranchViewModel>>(result);

            var bankBranches = from m in model
                         select new
                         {
                             m.Id,
                             m.Name
                         };

            return Json(bankBranches);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BankBranchViewModel model)
        {
            if(ModelState.IsValid)
            {
                var bankBranches = _mapper.Map<BankBranchViewModel, BankBranch>(model);
                bankBranches.Id = Guid.NewGuid();
                bankBranches.DateAdded = DateTime.Now;

                await _unitOfWork.BankBranches.Add(bankBranches);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.BankBranches.GetById(id);

            var model = _mapper.Map<BankBranch, BankBranchViewModel>(result);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.BankBranches.GetById(id);

            var model = _mapper.Map<BankBranch, BankBranchViewModel>(result);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, BankBranchViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                var bankBranches = _mapper.Map<BankBranchViewModel, BankBranch>(model);
                bankBranches.DateModified = DateTime.Now;

                await _unitOfWork.BankBranches.Update(bankBranches);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.BankBranches.GetById(id);

            var model = _mapper.Map<BankBranch, BankBranchViewModel>(result);            
            return View(model);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.BankBranches.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}