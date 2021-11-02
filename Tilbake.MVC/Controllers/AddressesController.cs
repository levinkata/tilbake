using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

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

            AddressSaveResource resource = new()
            {
                PortfolioId = portfolioId,
                ClientId = clientId,
                CountryList = SelectLists.Countries(countries, Guid.Empty),
                CityList = SelectLists.Cities(cities, Guid.Empty)
            };
            
            return View(resource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddressSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _addressService.AddAsync(resource);
                if (resource.PortfolioId != Guid.Empty && resource.ClientId != Guid.Empty)
                {
                    return RedirectToAction("Details", "PortfolioClients", new { portfolioId = resource.PortfolioId, clientId = resource.ClientId });
                }
                return RedirectToAction(nameof(Index));
            }

            var cityId = resource.CityId;
            var city = await _cityService.GetByIdAsync(cityId);
            var countryId = city.CountryId;

            var countries = await _countryService.GetAllAsync();
            var cities = await _cityService.GetByCountryId(countryId);

            resource.CountryId = countryId;
            resource.CountryList = SelectLists.Countries(countries, countryId);
            resource.CityList = SelectLists.Cities(cities, cityId);            
            return View(resource);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var resource = await _addressService.GetByIdAsync(id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid portfolioId, Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _addressService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            var cityId = resource.CityId;
            var city = await _cityService.GetByIdAsync(cityId);
            var countryId = city.CountryId;

            var countries = await _countryService.GetAllAsync();
            var cities = await _cityService.GetByCountryId(countryId);

            resource.PortfolioId = portfolioId;
            resource.CountryId = countryId;
            resource.CountryList = SelectLists.Countries(countries, countryId);
            resource.CityList = SelectLists.Cities(cities, cityId);
            return View(resource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, AddressResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _addressService.UpdateAsync(resource);
                    if (resource.PortfolioId != Guid.Empty && resource.ClientId != Guid.Empty)
                    {
                        return RedirectToAction("Details", "PortfolioClients", new { portfolioId = resource.PortfolioId, clientId = resource.ClientId });
                    }                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Details), "PortfolioClients", new { portfolioId = Guid.Empty, clientId = resource.ClientId });
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

        [HttpGet]
        public async Task<IActionResult> GetByClientId(Guid clientId)
        {
            var resource = await _addressService.GetByClientIdAsync(clientId);

            return Ok(new { resource });
        }

        [HttpPut]
        public IActionResult PutAddress(AddressResource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            };

            _addressService.UpdateAsync(resource);

            return Ok();
        }
    }
}
