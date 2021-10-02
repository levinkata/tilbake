using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    [Authorize]
    public class InsurerBranchesController : Controller
    {
        private readonly IInsurerBranchService _insurerBranchService;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        private readonly IInsurerService _insurerService;

        public InsurerBranchesController(IInsurerBranchService insurerBranchService,
                                        ICountryService countryService,
                                        ICityService cityService,
                                        IInsurerService insurerService)
        {
            _insurerBranchService = insurerBranchService;
            _countryService = countryService;
            _cityService = cityService;
            _insurerService = insurerService;
        }

        // GET: InsurerBranches
        public async Task<IActionResult> Index(Guid insurerId)
        {
            ViewBag.InsurerId = insurerId;
            return View(await _insurerBranchService.GetByInsurerIdAsync(insurerId));
        }

        [HttpGet]
        public async Task<IActionResult> GetInsurerBranches(Guid insurerId)
        {
            var resources = await _insurerBranchService.GetByInsurerIdAsync(insurerId);
            var insurerBranches = from m in resources
                              select new
                              {
                                  m.Id,
                                  m.Name
                              };

            return Json(insurerBranches);
        }

        // GET: InsurerBranches/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _insurerBranchService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // GET: InsurerBranches/Create
        public async Task<IActionResult> Create(Guid insurerId)
        {
            var countries = await _countryService.GetAllAsync();
            var insurer = await _insurerService.GetByIdAsync(insurerId);

            InsurerBranchSaveResource resource = new()
            {
                InsurerId = insurerId,
                Insurer = insurer.Name,
                CountryList = SelectLists.Countries(countries, Guid.Empty)
            };
            return View(resource);
        }

        // POST: InsurerBranches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsurerBranchSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _insurerBranchService.AddAsync(resource);
                return RedirectToAction(nameof(Details), "Insurers", new { id = resource.InsurerId });
            }
            var cityId = resource.CityId;
            var city = await _cityService.GetByIdAsync(cityId);
            var countryId = city.CountryId;

            var countries = await _countryService.GetAllAsync();
            var cities = await _cityService.GetByCountryId(countryId);

            resource.CityList = SelectLists.Cities(cities, cityId);
            resource.CountryList = SelectLists.Countries(countries, countryId);
            return View(resource);
        }

        // GET: InsurerBranches/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _insurerBranchService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }
            var cityId = resource.CityId;
            var city = await _cityService.GetByIdAsync(cityId);
            var countryId = city.CountryId;

            var countries = await _countryService.GetAllAsync();
            var cities = await _cityService.GetByCountryId(countryId);

            resource.CountryId = countryId;
            resource.CityList = SelectLists.Cities(cities, cityId);
            resource.CountryList = SelectLists.Countries(countries, countryId);
            return View(resource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, InsurerBranchResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _insurerBranchService.UpdateAsync(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Details), new { id = resource.Id });
            }

            var cityId = resource.CityId;
            var city = await _cityService.GetByIdAsync(cityId);
            var countryId = city.CountryId;

            var countries = await _countryService.GetAllAsync();
            var cities = await _cityService.GetByCountryId(countryId);

            resource.CountryId = countryId;
            resource.CityList = SelectLists.Cities(cities, cityId);
            resource.CountryList = SelectLists.Countries(countries, countryId);
            return View(resource);
        }

        // GET: InsurerBranches/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _insurerBranchService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: InsurerBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(InsurerBranchResource resource)
        {
            await _insurerBranchService.DeleteAsync(resource.Id);
            return RedirectToAction(nameof(Details), "Insurers", new { id = resource.InsurerId });
        }
    }
}
