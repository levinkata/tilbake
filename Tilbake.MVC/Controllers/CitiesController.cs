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
    public class CitiesController : BaseController
    {
        public CitiesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Cities.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<City>, IEnumerable<CityViewModel>>(result);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetCities(Guid countryId)
        {
            var result = await _unitOfWork.Cities.GetByCountryId(countryId);
            var model = _mapper.Map<IEnumerable<City>, IEnumerable<CityViewModel>>(result);

            var cities = from m in model
                         select new
                         {
                             m.Id,
                             m.Name
                         };

            return Json(cities);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CityViewModel model)
        {
            if(ModelState.IsValid)
            {
                var city = _mapper.Map<CityViewModel, City>(model);
                city.Id = Guid.NewGuid();
                city.DateAdded = DateTime.Now;

                await _unitOfWork.Cities.Add(city);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.Cities.GetById(id);

            var model = _mapper.Map<City, CityViewModel>(result);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.Cities.GetById(id);

            var model = _mapper.Map<City, CityViewModel>(result);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, CityViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                var city = _mapper.Map<CityViewModel, City>(model);
                city.DateModified = DateTime.Now;

                await _unitOfWork.Cities.Update(city);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.Cities.GetById(id);

            var model = _mapper.Map<City, CityViewModel>(result);            
            return View(model);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.Cities.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}