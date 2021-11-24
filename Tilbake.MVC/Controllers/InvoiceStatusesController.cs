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
    public class InvoiceStatusesController : BaseController
    {
        public InvoiceStatusesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: InvoiceStatuses
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.InvoiceStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<InvoiceStatus>, IEnumerable<InvoiceStatusViewModel>>(result);
            return View(model);
        }

        // GET: InvoiceStatuses/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.InvoiceStatuses.GetById(id);
            var model = _mapper.Map<InvoiceStatus, InvoiceStatusViewModel>(result);
            return View(model);
        }

        // GET: InvoiceStatuses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvoiceStatuses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvoiceStatusViewModel model)
        {
            if (ModelState.IsValid)
            {
                var invoiceStatus = _mapper.Map<InvoiceStatusViewModel, InvoiceStatus>(model);
                invoiceStatus.Id = Guid.NewGuid();
                invoiceStatus.DateAdded = DateTime.Now;

                await _unitOfWork.InvoiceStatuses.Add(invoiceStatus);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: InvoiceStatuses/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.InvoiceStatuses.GetById(id);
            var model = _mapper.Map<InvoiceStatus, InvoiceStatusViewModel>(result);
            return View(model);
        }

        // POST: InvoiceStatuses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, InvoiceStatusViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var invoiceStatus = _mapper.Map<InvoiceStatusViewModel, InvoiceStatus>(model);
                invoiceStatus.DateModified = DateTime.Now;

                await _unitOfWork.InvoiceStatuses.Update(invoiceStatus);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: InvoiceStatuses/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.InvoiceStatuses.GetById(id);
            var model = _mapper.Map<InvoiceStatus, InvoiceStatusViewModel>(result);
            return View(model);
        }

        // POST: InvoiceStatuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.InvoiceStatuses.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
