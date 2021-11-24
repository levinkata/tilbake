using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class PayeeTypesController : BaseController
    {
        public PayeeTypesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: PayeeTypes
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.PayeeTypes.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<PayeeType>, IEnumerable<PayeeTypeViewModel>>(result);
            return View(model);
        }

        // GET: PayeeTypes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.PayeeTypes.GetById(id);
            var model = _mapper.Map<PayeeType, PayeeTypeViewModel>(result);
            return View(model);
        }

        // GET: PayeeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PayeeTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PayeeTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var payeeType = _mapper.Map<PayeeTypeViewModel, PayeeType>(model);
                payeeType.Id = Guid.NewGuid();
                payeeType.DateAdded = DateTime.Now;

                await _unitOfWork.PayeeTypes.Add(payeeType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: PayeeTypes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.PayeeTypes.GetById(id);
            var model = _mapper.Map<PayeeType, PayeeTypeViewModel>(result);
            return View(model);
        }

        // POST: PayeeTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, PayeeTypeViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var payeeType = _mapper.Map<PayeeTypeViewModel, PayeeType>(model);
                payeeType.DateModified = DateTime.Now;

                await _unitOfWork.PayeeTypes.Update(payeeType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: PayeeTypes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.PayeeTypes.GetById(id);
            var model = _mapper.Map<PayeeType, PayeeTypeViewModel>(result);
            return View(model);
        }

        // POST: PayeeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.PayeeTypes.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
