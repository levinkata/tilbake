using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class AddressesController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;

        public AddressesController(IAddressService addressService,
                                    ICountryService countryService,
                                    ICityService cityService)
        {
            _addressService = addressService;
            _countryService = countryService;
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid portfolioId, Guid clientId)
        {
            var countries = await _countryService.GetAllAsync();
            var cities = await _cityService.GetByCountryId(Guid.Empty);

            AddressViewModel ViewModel = new()
            {
                PortfolioId = portfolioId,
                ClientId = clientId,
                CountryList = SelectLists.Countries(countries, Guid.Empty),
                CityList = SelectLists.Cities(cities, Guid.Empty)
            };
            
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddressViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                await _addressService.AddAsync(ViewModel);
                if (ViewModel.PortfolioId != Guid.Empty && ViewModel.ClientId != Guid.Empty)
                {
                    return RedirectToAction("Details", "PortfolioClients", new { portfolioId = ViewModel.PortfolioId, clientId = ViewModel.ClientId });
                }
                return RedirectToAction(nameof(Index));
            }

            var cityId = ViewModel.CityId;
            var city = await _cityService.GetByIdAsync(cityId);
            var countryId = city.CountryId;

            var countries = await _countryService.GetAllAsync();
            var cities = await _cityService.GetByCountryId(countryId);

            ViewModel.CountryId = countryId;
            ViewModel.CountryList = SelectLists.Countries(countries, countryId);
            ViewModel.CityList = SelectLists.Cities(cities, cityId);            
            return View(ViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var ViewModel = await _addressService.GetByIdAsync(id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid portfolioId, Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _addressService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            var cityId = ViewModel.CityId;
            var city = await _cityService.GetByIdAsync(cityId);
            var countryId = city.CountryId;

            var countries = await _countryService.GetAllAsync();
            var cities = await _cityService.GetByCountryId(countryId);

            ViewModel.PortfolioId = portfolioId;
            ViewModel.CountryId = countryId;
            ViewModel.CountryList = SelectLists.Countries(countries, countryId);
            ViewModel.CityList = SelectLists.Cities(cities, cityId);
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, AddressViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _addressService.UpdateAsync(ViewModel);
                    if (ViewModel.PortfolioId != Guid.Empty && ViewModel.ClientId != Guid.Empty)
                    {
                        return RedirectToAction("Details", "PortfolioClients", new { portfolioId = ViewModel.PortfolioId, clientId = ViewModel.ClientId });
                    }                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Details), "PortfolioClients", new { portfolioId = Guid.Empty, clientId = ViewModel.ClientId });
            }

            var cityId = ViewModel.CityId;
            var city = await _cityService.GetByIdAsync(cityId);
            var countryId = city.CountryId;

            var countries = await _countryService.GetAllAsync();
            var cities = await _cityService.GetByCountryId(countryId);

            ViewModel.CityList = SelectLists.Cities(cities, cityId);
            ViewModel.CountryList = SelectLists.Countries(countries, countryId);

            return View(ViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetByClientId(Guid clientId)
        {
            var ViewModel = await _addressService.GetByClientIdAsync(clientId);

            return Ok(new { ViewModel });
        }

        [HttpPut]
        public IActionResult PutAddress(AddressViewModel ViewModel)
        {
            if (ViewModel == null)
            {
                throw new ArgumentNullException(nameof(ViewModel));
            };

            _addressService.UpdateAsync(ViewModel);

            return Ok();
        }
    }
}
