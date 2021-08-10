using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    public class PortfolioClientsController : Controller
    {
        public const string SessionPortfolioName = "_PortfolioName";
        public const string SessionPortfolioId = "_PortfolioId";

        private readonly IPortfolioClientService _portfolioClientService;
        private readonly IClientService _clientService;
        private readonly IClientTypeService _clientTypeService;
        private readonly ICountryService _countryService;
        private readonly IGenderService _genderService;
        private readonly IMaritalStatusService _maritalStatusService;
        private readonly IOccupationService _occupationService;
        private readonly ITitleService _titleService;
        private readonly ICarrierService _carrierService;
        private readonly IPortfolioService _portfolioService;
        private readonly IClientCarrierService _clientCarrierService;

        public PortfolioClientsController(IPortfolioClientService portfolioClientService,
                                            IClientService clientService,
                                            IClientTypeService clientTypeService,
                                            ICountryService countryService,
                                            IGenderService genderService,
                                            IMaritalStatusService maritalStatusService,
                                            IOccupationService occupationService,
                                            ITitleService titleService,
                                            ICarrierService carrierService,
                                            IPortfolioService portfolioService,
                                            IClientCarrierService clientCarrierService)
        {
            _portfolioClientService = portfolioClientService;
            _clientService = clientService;
            _clientTypeService = clientTypeService;
            _countryService = countryService;
            _genderService = genderService;
            _maritalStatusService = maritalStatusService;
            _occupationService = occupationService;
            _titleService = titleService;
            _carrierService = carrierService;
            _portfolioService = portfolioService;
            _clientCarrierService = clientCarrierService;
        }

        // GET: PortfolioClients
        public async Task<IActionResult> Index(Guid portfolioId)
        {
            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);

            ClientResource resource = new()
            {
                PortfolioId = portfolioId,
                PortfolioName = portfolio.Name
            };

            return await Task.Run(() => View(resource));
        }

        // GET: PortfolioClients/Details/5
        public async Task<IActionResult> Details(Guid portfolioId, Guid clientId)
        {
            var portfolioClientId = await _portfolioClientService.GetPortfolioClientId(portfolioId, clientId);
            var resource = await _clientService.GetByClientId(portfolioId, clientId);
            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);

            if (resource == null)
            {
                return NotFound();
            }
            resource.PortfolioId = portfolioId;
            resource.PortfolioClientId = portfolioClientId;
            resource.PortfolioName = portfolio.Name;

            return View(resource);
        }

        // GET: PortfolioClients/Create
        public async Task<IActionResult> Create(Guid portfolioId)
        {
            var clientTypes = await _clientTypeService.GetAllAsync();
            var countries = await _countryService.GetAllAsync();
            var genders = await _genderService.GetAllAsync();
            var maritalStatuses = await _maritalStatusService.GetAllAsync();
            var occupations = await _occupationService.GetAllAsync();
            var titles = await _titleService.GetAllAsync();
            // var carriers = await _carrierService.GetAllAsync();

            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);

            // Requires: using Microsoft.AspNetCore.Http;
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionPortfolioName)))
            {
                HttpContext.Session.SetString(SessionPortfolioName, portfolio.Name);
                HttpContext.Session.SetString(SessionPortfolioId, portfolioId.ToString());
            }
            
            ClientSaveResource resource = new()
            {
                PortfolioId = portfolioId,
                PortfolioName = portfolio.Name,
                ClientTypeList = new SelectList(clientTypes, "Id", "Name"),
                CountryList = new SelectList(countries, "Id", "Name"),
                GenderList = new SelectList(genders, "Id", "Name"),
                MaritalStatusList = new SelectList(maritalStatuses, "Id", "Name"),
                OccupationList = SelectLists.Occupations(occupations, Guid.Empty),
                TitleList = SelectLists.Titles(titles, Guid.Empty)
                // CarrierList = SelectLists.Carriers(carriers, carrierIds)
            };
            return View("CreateClient", resource);
        }

        // POST: PortfolioClients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _portfolioClientService.AddClientAsync(resource);
                return RedirectToAction(nameof(Index), new { resource.PortfolioId });
            }

            var clientTypes = await _clientTypeService.GetAllAsync();
            var countries = await _countryService.GetAllAsync();
            var genders = await _genderService.GetAllAsync();
            var maritalStatuses = await _maritalStatusService.GetAllAsync();
            var occupations = await _occupationService.GetAllAsync();
            var titles = await _titleService.GetAllAsync();
            var carriers = await _carrierService.GetAllAsync();

            resource.ClientTypeList = new SelectList(clientTypes, "Id", "Name", resource.ClientTypeId);
            resource.CountryList = new SelectList(countries, "Id", "Name", resource.CountryId);
            resource.GenderList = new SelectList(genders, "Id", "Name", resource.GenderId);
            resource.MaritalStatusList = new SelectList(maritalStatuses, "Id", "Name", resource.MaritalStatusId);
            resource.OccupationList = SelectLists.Occupations(occupations, resource.OccupationId);
            resource.TitleList = SelectLists.Titles(titles, resource.TitleId);

            return View(resource);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid portfolioId, Guid clientId)
        {
            var clientTypes = await _clientTypeService.GetAllAsync();
            var countries = await _countryService.GetAllAsync();
            var genders = await _genderService.GetAllAsync();
            var maritalStatuses = await _maritalStatusService.GetAllAsync();
            var occupations = await _occupationService.GetAllAsync();
            var titles = await _titleService.GetAllAsync();
            var carriers = await _carrierService.GetAllAsync();

            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);
            var clientCarriers = await _clientCarrierService.GetByClientIdAsync(clientId);

            var resource = await _clientService.GetByIdAsync(clientId);
            
            int counter = 0;
            foreach (var item in resource.ClientCarriers)
            {
                resource.CarrierIds[counter] = item.CarrierId;
                counter++;
            }

            resource.PortfolioId = portfolioId;
            resource.PortfolioName = portfolio.Name;
            resource.ClientTypeList = new SelectList(clientTypes, "Id", "Name", resource.ClientTypeId);
            resource.CountryList = new SelectList(countries, "Id", "Name", resource.CountryId);
            resource.GenderList = new SelectList(genders, "Id", "Name", resource.GenderId);
            resource.MaritalStatusList = new SelectList(maritalStatuses, "Id", "Name", resource.MaritalStatusId);
            resource.OccupationList = SelectLists.Occupations(occupations, resource.OccupationId);
            resource.TitleList = SelectLists.Titles(titles, resource.TitleId);
            resource.CarrierList = SelectLists.Carriers(carriers, resource.CarrierIds);
            resource.ClientCarrierResources.AddRange(clientCarriers);

            return await Task.Run(() => View("EditClient", resource));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClientResource resource)
        {
            if(ModelState.IsValid)
            {
                await _clientService.UpdateAsync(resource);
                return RedirectToAction(nameof(Edit), new { portfolioId = resource.PortfolioId, clientId = resource.Id });
            }
            return View("EditClient", resource);
        }

        // GET: PortfolioClients/Delete/5
        public async Task<IActionResult> Delete(Guid? portfolioId, Guid? clientId)
        {
            if (portfolioId == null || clientId == null)
            {
                return NotFound();
            }

            var resource = await _clientService.GetByClientId((Guid)portfolioId, (Guid)clientId);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: PortfolioClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _portfolioClientService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
