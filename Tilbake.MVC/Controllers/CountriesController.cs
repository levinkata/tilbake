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
    public class CountriesController : BaseController
    {
        public CountriesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Countries.GetAll(r => r.OrderBy(n => n.Name));

            var model = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryViewModel>>(result);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var result = await _unitOfWork.Countries.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryViewModel>>(result);

            var countries = from m in model
                         select new
                         {
                             m.Id,
                             m.Name
                         };

            return Json(countries);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CountryViewModel model)
        {
            if(ModelState.IsValid)
            {
                var country = _mapper.Map<CountryViewModel, Country>(model);
                country.Id = Guid.NewGuid();
                country.DateAdded = DateTime.Now;

                await _unitOfWork.Countries.Add(country);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.Countries.GetById(id);

            var model = _mapper.Map<Country, CountryViewModel>(result);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.Countries.GetById(id);

            var model = _mapper.Map<Country, CountryViewModel>(result);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, CountryViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                var country = _mapper.Map<CountryViewModel, Country>(model);
                country.DateModified = DateTime.Now;

                await _unitOfWork.Countries.Update(country);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.Countries.GetById(id);

            var model = _mapper.Map<Country, CountryViewModel>(result);            
            return View(model);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.Countries.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}