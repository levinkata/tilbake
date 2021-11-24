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
    public class PaymentMethodsController : BaseController
    {
        public PaymentMethodsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: PaymentMethods
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.PaymentMethods.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<PaymentMethod>, IEnumerable<PaymentMethodViewModel>>(result);
            return View(model);
        }

        // GET: PaymentMethods/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.PaymentMethods.GetById(id);
            var model = _mapper.Map<PaymentMethod, PaymentMethodViewModel>(result);
            return View(model);
        }

        // GET: PaymentMethods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentMethods/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentMethodViewModel model)
        {
            if (ModelState.IsValid)
            {
                var paymentMethod = _mapper.Map<PaymentMethodViewModel, PaymentMethod>(model);
                paymentMethod.Id = Guid.NewGuid();
                paymentMethod.DateAdded = DateTime.Now;

                await _unitOfWork.PaymentMethods.Add(paymentMethod);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: PaymentMethods/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.PaymentMethods.GetById(id);
            var model = _mapper.Map<PaymentMethod, PaymentMethodViewModel>(result);
            return View(model);
        }

        // POST: PaymentMethods/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, PaymentMethodViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var paymentMethod = _mapper.Map<PaymentMethodViewModel, PaymentMethod>(model);
                paymentMethod.DateModified = DateTime.Now;

                await _unitOfWork.PaymentMethods.Update(paymentMethod);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: PaymentMethods/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.PaymentMethods.GetById(id);
            var model = _mapper.Map<PaymentMethod, PaymentMethodViewModel>(result);
            return View(model);
        }

        // POST: PaymentMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.PaymentMethods.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
