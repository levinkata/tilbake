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
    public class BanksController : BaseController
    {
        public BanksController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Banks.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<Bank>, IEnumerable<BankViewModel>>(result);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetBanks()
        {
            var result = await _unitOfWork.Banks.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<Bank>, IEnumerable<BankViewModel>>(result);

            var banks = from m in model
                           select new
                           {
                               m.Id,
                               m.Name
                           };

            return Json(banks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BankViewModel model)
        {
            if(ModelState.IsValid)
            {
                var bank = _mapper.Map<BankViewModel, Bank>(model);
                bank.Id = Guid.NewGuid();
                bank.DateAdded = DateTime.Now;

                await _unitOfWork.Banks.Add(bank);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.Banks.GetById(id);

            var model = _mapper.Map<Bank, BankViewModel>(result);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.Banks.GetById(id);

            var model = _mapper.Map<Bank, BankViewModel>(result);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, BankViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                var bank = _mapper.Map<BankViewModel, Bank>(model);
                bank.DateModified = DateTime.Now;

                await _unitOfWork.Banks.Update(bank);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.Banks.GetById(id);

            var model = _mapper.Map<Bank, BankViewModel>(result);            
            return View(model);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.Banks.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}