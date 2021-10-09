using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Enums;

namespace Tilbake.MVC.Controllers
{
    public class PortfolioClientsController : Controller
    {
        private readonly IPortfolioClientService _portfolioClientService;
        private readonly ICityService _cityService;
        private readonly IClientService _clientService;
        private readonly IClientTypeService _clientTypeService;
        private readonly ICountryService _countryService;
        private readonly IGenderService _genderService;
        private readonly IIdDocumentTypeService _idDocumentTypeService;
        private readonly IMaritalStatusService _maritalStatusService;
        private readonly IOccupationService _occupationService;
        private readonly ITitleService _titleService;
        private readonly ICarrierService _carrierService;
        private readonly IPortfolioService _portfolioService;
        private readonly IClientCarrierService _clientCarrierService;
        private readonly IAddressService _addressService;

        public PortfolioClientsController(IPortfolioClientService portfolioClientService,
                                            ICityService cityService,
                                            IClientService clientService,
                                            IClientTypeService clientTypeService,
                                            ICountryService countryService,
                                            IGenderService genderService,
                                            IIdDocumentTypeService idDocumentTypeService,
                                            IMaritalStatusService maritalStatusService,
                                            IOccupationService occupationService,
                                            ITitleService titleService,
                                            ICarrierService carrierService,
                                            IPortfolioService portfolioService,
                                            IClientCarrierService clientCarrierService,
                                            IAddressService addressService)
        {
            _portfolioClientService = portfolioClientService;
            _cityService = cityService;
            _clientService = clientService;
            _clientTypeService = clientTypeService;
            _countryService = countryService;
            _genderService = genderService;
            _idDocumentTypeService = idDocumentTypeService;
            _maritalStatusService = maritalStatusService;
            _occupationService = occupationService;
            _titleService = titleService;
            _carrierService = carrierService;
            _portfolioService = portfolioService;
            _clientCarrierService = clientCarrierService;
            _addressService = addressService;
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

            return View(resource);
        }

        public async Task<IActionResult> Search(Guid portfolioId, string searchString = "~#")
        {
            var resource = await _portfolioService.GetByIdAsync(portfolioId);
            var resources = await _clientService.GetByPortfolioIdAsync(portfolioId);

            if (!String.IsNullOrEmpty(searchString) && portfolioId != Guid.Empty)
            {
                resources = resources.Where(r => r.LastName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                        || r.FirstName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                        || r.IdNumber.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
            }

            PortfolioClientSearchResource searchResource = new()
            {
                PortfolioId = portfolioId,
                PortfolioName = resource.Name,
                SearchString = "",
                ClientResources = resources.ToList()
            };
            return View(searchResource);
        }

        public async Task<IActionResult> ImportBulk(Guid portfolioId, Guid fileTemplateId, FileType fileType, string delimiter)
        {
            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);

            UpLoadFileResource resource = new()
            {
                PortfolioId = portfolioId,
                PortfolioName = portfolio.Name,
                FileTemplateId = fileTemplateId,
                FileType = fileType,
                Delimiter = delimiter,
                TableName = "Client"
            };
            return View(resource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportBulk(UpLoadFileResource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            };

            if (ModelState.IsValid)
            {
                await _clientService.ImportBulkAsync(resource);
                return RedirectToAction(nameof(LoadBulks), new { resource.PortfolioId });
            }

            return View(resource);
        }

        public async Task<IActionResult> LoadBulks(Guid portfolioId)
        {
            var resources = await _clientService.GetBulkByPortfolioIdAsync(portfolioId);
            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);

            ViewBag.PortfolioId = portfolioId;
            ViewBag.PortfolioName = portfolio.Name;

            return View(resources);
        }

        [HttpPost, ActionName("LoadBulks")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoadConfirmed(List<ClientBulkResource> resources)
        {
            if (resources == null)
            {
                throw new ArgumentNullException(nameof(resources));
            };

            var portfolioId = resources.GroupBy(r => r.PortfolioId).FirstOrDefault().Key;
            var portfolio = await _portfolioService.GetByIdAsync((Guid)portfolioId);

            if (ModelState.IsValid)
            {
                await _clientService.AddBulkAsync((Guid)portfolioId);
                return RedirectToAction(nameof(Index), new { portfolioId });
            }
            else
            {
                ModelState.AddModelError("", "Encountered possible error - Model is invalid");
                ViewBag.PortfolioId = portfolioId;
                ViewBag.PortfolioName = portfolio.Name;
                return View(resources);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPortfolioClients(Guid portfolioId, string category, string searchString)
        {
            var resources = await _clientService.GetByPortfolioIdAsync(portfolioId);

            switch (category)
            {
                case "Client Number":
                    bool isNumber = int.TryParse(searchString, out int n);
                    if (isNumber)
                    {
                        resources = resources.Where(r => r.ClientNumber == n);
                    }
                    break;
                case "Id Number":
                    resources = resources.Where(r => r.IdNumber == searchString);
                    break;
                case "Name":
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        resources = resources.Where(r => r.LastName.Contains(searchString)
                                                || r.FirstName.Contains(searchString));
                    }
                    break;
                default:
                    break;
            }
            return Json(resources);
        }

        public async Task<IActionResult> Details(Guid portfolioId, Guid clientId)
        {
            var portfolioClientId = await _portfolioClientService.GetPortfolioClientId(portfolioId, clientId);
            var resource = await _clientService.GetByClientIdAsync(portfolioId, clientId);
            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);
            var clientCarriers = await _clientCarrierService.GetByClientIdAsync(clientId);
            var address = await _addressService.GetByClientIdAsync(clientId);

            resource.Address = address;
            resource.ClientCarriers.AddRange(clientCarriers);

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
            var carriers = await _carrierService.GetAllAsync();
            var clientTypes = await _clientTypeService.GetAllAsync();
            var countries = await _countryService.GetAllAsync();
            var genders = await _genderService.GetAllAsync();
            var idDocumentTypes = await _idDocumentTypeService.GetAllAsync();
            var maritalStatuses = await _maritalStatusService.GetAllAsync();
            var occupations = await _occupationService.GetAllAsync();
            var titles = await _titleService.GetAllAsync();

            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);

            PortfolioClientSaveResource resource = new()
            {
                PortfolioId = portfolioId,
                PortfolioName = portfolio.Name,
                BirthDate = DateTime.Now.Date,
                AddressCountryList = SelectLists.Countries(countries, Guid.Empty),
                ClientTypeList = SelectLists.ClientTypes(clientTypes, Guid.Empty),
                CountryList = SelectLists.Countries(countries, Guid.Empty),
                GenderList = SelectLists.Genders(genders, Guid.Empty),
                IdDocumentTypeList = SelectLists.IdDocumentTypes(idDocumentTypes, Guid.Empty),
                MaritalStatusList = SelectLists.MaritalStatuses(maritalStatuses, Guid.Empty),
                OccupationList = SelectLists.Occupations(occupations, Guid.Empty),
                TitleList = SelectLists.Titles(titles, Guid.Empty)
            };
            resource.CarrierList = SelectLists.Carriers(carriers, resource.CarrierIds);
            return View(resource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioClientSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _portfolioClientService.AddAsync(resource);
                return RedirectToAction(nameof(Search), new { portfolioId = resource.PortfolioId, searchString = resource.LastName});
            }

            var cities = await _cityService.GetByCountryId(resource.CountryId);
            var clientTypes = await _clientTypeService.GetAllAsync();
            var countries = await _countryService.GetAllAsync();
            var genders = await _genderService.GetAllAsync();
            var idDocumentTypes = await _idDocumentTypeService.GetAllAsync();
            var maritalStatuses = await _maritalStatusService.GetAllAsync();
            var occupations = await _occupationService.GetAllAsync();
            var titles = await _titleService.GetAllAsync();
            var carriers = await _carrierService.GetAllAsync();

            resource.AddressCountryList = new SelectList(countries, "Id", "Name", resource.CountryId);
            resource.CarrierList = SelectLists.Carriers(carriers, resource.CarrierIds);
            resource.CityList = new SelectList(cities, "Id", "Name", resource.CityId);
            resource.ClientTypeList = new SelectList(clientTypes, "Id", "Name", resource.ClientTypeId);
            resource.CountryList = new SelectList(countries, "Id", "Name", resource.CountryId);
            resource.GenderList = new SelectList(genders, "Id", "Name", resource.GenderId);
            resource.IdDocumentTypeList = SelectLists.IdDocumentTypes(idDocumentTypes, resource.IdDocumentTypeId);
            resource.MaritalStatusList = new SelectList(maritalStatuses, "Id", "Name", resource.MaritalStatusId);
            resource.OccupationList = SelectLists.Occupations(occupations, resource.OccupationId);
            resource.TitleList = SelectLists.Titles(titles, resource.TitleId);

            return View(resource);
        }

        [HttpPost]
        public async Task<IActionResult> AddExistingClient(Guid portfolioId, Guid clientId)
        {
            var resource = await _portfolioClientService.AddExistingClientAsync(portfolioId, clientId);
            return Json(resource);
        }

        public async Task<IActionResult> GetByIdNumber(Guid portfolioId, string idNumber)
        {
            var resource = await _portfolioClientService.GetByIdNumberAsync(portfolioId, idNumber);
            return Json(resource);
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

            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);
            var clientCarriers = await _clientCarrierService.GetByClientIdAsync(clientId);
            var address = await _addressService.GetByClientIdAsync(clientId);
            var resource = await _clientService.GetByIdAsync(clientId);

            resource.PortfolioId = portfolioId;
            resource.PortfolioName = portfolio.Name;
            resource.ClientTypeList = new SelectList(clientTypes, "Id", "Name", resource.ClientTypeId);
            resource.CountryList = new SelectList(countries, "Id", "Name", resource.CountryId);
            resource.GenderList = new SelectList(genders, "Id", "Name", resource.GenderId);
            resource.MaritalStatusList = new SelectList(maritalStatuses, "Id", "Name", resource.MaritalStatusId);
            resource.OccupationList = SelectLists.Occupations(occupations, resource.OccupationId);
            resource.TitleList = SelectLists.Titles(titles, resource.TitleId);
            resource.Address = address;
            resource.ClientCarriers.AddRange(clientCarriers);

            return View("EditClient", resource);
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
            return View(resource);
        }

        // GET: PortfolioClients/Delete/5
        public async Task<IActionResult> Delete(Guid? portfolioId, Guid? clientId)
        {
            if (portfolioId == null || clientId == null)
            {
                return NotFound();
            }

            var resource = await _clientService.GetByClientIdAsync((Guid)portfolioId, (Guid)clientId);
            if (resource == null)
            {
                return NotFound();
            }

            return View("EditClient", resource);
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
