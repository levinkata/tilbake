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
    public class CompaniesController : BaseController
    {
        public CompaniesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Companies.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyViewModel>>(result);
            return View(model);
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.Companies.GetById(id);
            var model = _mapper.Map<Company, CompanyViewModel>(result);
            return View(model);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var company = _mapper.Map<CompanyViewModel, Company>(model);
                company.Id = Guid.NewGuid();
                company.DateAdded = DateTime.Now;

                await _unitOfWork.Companies.Add(company);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.Companies.GetById(id);
            var model = _mapper.Map<Company, CompanyViewModel>(result);
            return View(model);
        }

        // POST: Companies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, CompanyViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var company = _mapper.Map<CompanyViewModel, Company>(model);
                company.DateModified = DateTime.Now;

                await _unitOfWork.Companies.Update(company);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.Companies.GetById(id);
            var model = _mapper.Map<Company, CompanyViewModel>(result);
            return View(model);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.Companies.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
