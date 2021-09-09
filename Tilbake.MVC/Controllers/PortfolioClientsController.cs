using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Enums;

namespace Tilbake.MVC.Controllers
{
    public class PortfolioClientsController : Controller
    {
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
        private readonly IAddressService _addressService;

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
                                            IClientCarrierService clientCarrierService,
                                            IAddressService addressService)
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

        public async Task<IActionResult> Search(Guid portfolioId, string searchString)
        {
            var resource = await _portfolioService.GetByIdAsync(portfolioId);
            var resources = await _clientService.GetByPortfolioIdAsync(portfolioId);
            ViewData["PortfolioId"] = portfolioId;
            ViewData["PortfolioName"] = resource.Name;
            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                resources = resources.Where(r => r.LastName.Contains(searchString)
                                        || r.FirstName.Contains(searchString));
            }
            return View(resources);
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
            var clientTypes = await _clientTypeService.GetAllAsync();
            var countries = await _countryService.GetAllAsync();
            var genders = await _genderService.GetAllAsync();
            var maritalStatuses = await _maritalStatusService.GetAllAsync();
            var occupations = await _occupationService.GetAllAsync();
            var titles = await _titleService.GetAllAsync();

            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);

            ClientSaveResource resource = new()
            {
                PortfolioId = portfolioId,
                PortfolioName = portfolio.Name,
                BirthDate = DateTime.Now.Date,
                ClientTypeList = new SelectList(clientTypes, "Id", "Name"),
                CountryList = new SelectList(countries, "Id", "Name"),
                GenderList = new SelectList(genders, "Id", "Name"),
                MaritalStatusList = new SelectList(maritalStatuses, "Id", "Name"),
                OccupationList = SelectLists.Occupations(occupations, Guid.Empty),
                TitleList = SelectLists.Titles(titles, Guid.Empty)
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

            return View("CreateClient", resource);
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
            return View("EditClient", resource);
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
