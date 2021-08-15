using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IClientTypeService _clientTypeService;
        private readonly ICountryService _countryService;
        private readonly IGenderService _genderService;
        private readonly IMaritalStatusService _maritalStatusService;
        private readonly IOccupationService _occupationService;
        private readonly ITitleService _titleService;
        private readonly ICarrierService _carrierService;

        public ClientsController(IClientService clientService,
                                IClientTypeService clientTypeService,
                                ICountryService countryService,
                                IGenderService genderService,
                                IMaritalStatusService maritalStatusService,
                                IOccupationService occupationService,
                                ITitleService titleService,
                                ICarrierService carrierService)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
            _clientTypeService = clientTypeService ?? throw new ArgumentNullException(nameof(clientTypeService));
            _countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));
            _genderService = genderService ?? throw new ArgumentNullException(nameof(genderService));
            _maritalStatusService = maritalStatusService ?? throw new ArgumentNullException(nameof(maritalStatusService));
            _occupationService = occupationService ?? throw new ArgumentNullException(nameof(occupationService));
            _titleService = titleService ?? throw new ArgumentNullException(nameof(titleService));
            _carrierService = carrierService ?? throw new ArgumentNullException(nameof(carrierService));
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => View());
        }

        // GET: Clients/GetByPortfolio/5
        public async Task<IActionResult> GetByPortfolio(Guid portfolioId)
        {
            PortfolioResource resource = new()
            {
                Id = portfolioId
            };
            
            return await Task.Run(() => View(resource));
        }

        // GET: Clients/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _clientService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // GET: Clients/Create
        public async Task<ActionResult> Create()
        {
            var clientTypes = await _clientTypeService.GetAllAsync();
            var countries = await _countryService.GetAllAsync();
            var genders = await _genderService.GetAllAsync();
            var maritalStatuses = await _maritalStatusService.GetAllAsync();
            var occupations = await _occupationService.GetAllAsync();
            var titles = await _titleService.GetAllAsync();

            ClientSaveResource resource = new()
            {
                ClientTypeList = new SelectList(clientTypes, "Id", "Name"),
                CountryList = new SelectList(countries, "Id", "Name"),
                GenderList = new SelectList(genders, "Id", "Name"),
                MaritalStatusList = new SelectList(maritalStatuses, "Id", "Name"),
                OccupationList = new SelectList(occupations, "Id", "Name"),
                TitleList = new SelectList(titles, "Id", "Name")
            };

            return View(resource);
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClientSaveResource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            if (ModelState.IsValid)
            {
                await _clientService.AddAsync(resource);
                return RedirectToAction(nameof(Index));
            }

            var clientTypes = await _clientTypeService.GetAllAsync();
            var countries = await _countryService.GetAllAsync();
            var genders = await _genderService.GetAllAsync();
            var maritalStatuses = await _maritalStatusService.GetAllAsync();
            var occupations = await _occupationService.GetAllAsync();
            var titles = await _titleService.GetAllAsync();

            resource.ClientTypeList = new SelectList(clientTypes, "Id", "Name", resource.ClientTypeId);
            resource.CountryList = new SelectList(countries, "Id", "Name", resource.CountryId);
            resource.GenderList = new SelectList(genders, "Id", "Name", resource.GenderId);
            resource.MaritalStatusList = new SelectList(maritalStatuses, "Id", "Name", resource.MaritalStatusId);
            resource.OccupationList = new SelectList(occupations, "Id", "Name", resource.OccupationId);
            resource.TitleList = new SelectList(titles, "Id", "Name", resource.TitleId);

            return View(resource);
        }

        // GET: Clients/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var resource = await _clientService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            var clientTypes = await _clientTypeService.GetAllAsync();
            var countries = await _countryService.GetAllAsync();
            var genders = await _genderService.GetAllAsync();
            var maritalStatuses = await _maritalStatusService.GetAllAsync();
            var occupations = await _occupationService.GetAllAsync();
            var titles = await _titleService.GetAllAsync();

            resource.ClientTypeList = new SelectList(clientTypes, "Id", "Name", resource.ClientTypeId);
            resource.CountryList = new SelectList(countries, "Id", "Name", resource.CountryId);
            resource.GenderList = new SelectList(genders, "Id", "Name", resource.GenderId);
            resource.MaritalStatusList = new SelectList(maritalStatuses, "Id", "Name", resource.MaritalStatusId);
            resource.OccupationList = new SelectList(occupations, "Id", "Name", resource.OccupationId);
            resource.TitleList = new SelectList(titles, "Id", "Name", resource.TitleId);

            return View(resource);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, ClientResource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _clientService.UpdateAsync(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            var clientTypes = await _clientTypeService.GetAllAsync();
            var countries = await _countryService.GetAllAsync();
            var genders = await _genderService.GetAllAsync();
            var maritalStatuses = await _maritalStatusService.GetAllAsync();
            var occupations = await _occupationService.GetAllAsync();
            var titles = await _titleService.GetAllAsync();

            resource.ClientTypeList = new SelectList(clientTypes, "Id", "Name", resource.ClientTypeId);
            resource.CountryList = new SelectList(countries, "Id", "Name", resource.CountryId);
            resource.GenderList = new SelectList(genders, "Id", "Name", resource.GenderId);
            resource.MaritalStatusList = new SelectList(maritalStatuses, "Id", "Name", resource.MaritalStatusId);
            resource.OccupationList = new SelectList(occupations, "Id", "Name", resource.OccupationId);
            resource.TitleList = new SelectList(titles, "Id", "Name", resource.TitleId);

            return View(resource);
        }

        // GET: Clients/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _clientService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: Clients/Delete/5
        [HttpPost]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            await _clientService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
