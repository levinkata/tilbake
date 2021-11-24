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
    public class PaymentTypesController : BaseController
    {
        public PaymentTypesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: PaymentTypes
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.PaymentTypes.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<PaymentType>, IEnumerable<PaymentTypeViewModel>>(result);
            return View(model);
        }

        // GET: PaymentTypes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.PaymentTypes.GetById(id);
            var model = _mapper.Map<PaymentType, PaymentTypeViewModel>(result);
            return View(model);
        }

        // GET: PaymentTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var paymentType = _mapper.Map<PaymentTypeViewModel, PaymentType>(model);
                paymentType.Id = Guid.NewGuid();
                paymentType.DateAdded = DateTime.Now;

                await _unitOfWork.PaymentTypes.Add(paymentType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: PaymentTypes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.PaymentTypes.GetById(id);
            var model = _mapper.Map<PaymentType, PaymentTypeViewModel>(result);
            return View(model);
        }

        // POST: PaymentTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, PaymentTypeViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var paymentType = _mapper.Map<PaymentTypeViewModel, PaymentType>(model);
                paymentType.DateModified = DateTime.Now;

                await _unitOfWork.PaymentTypes.Update(paymentType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: PaymentTypes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.PaymentTypes.GetById(id);
            var model = _mapper.Map<PaymentType, PaymentTypeViewModel>(result);
            return View(model);
        }

        // POST: PaymentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.PaymentTypes.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
