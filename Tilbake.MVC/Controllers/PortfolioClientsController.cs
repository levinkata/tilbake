using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

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

        public PortfolioClientsController(IPortfolioClientService portfolioClientService,
                                            IClientService clientService,
                                            IClientTypeService clientTypeService,
                                            ICountryService countryService,
                                            IGenderService genderService,
                                            IMaritalStatusService maritalStatusService,
                                            IOccupationService occupationService,
                                            ITitleService titleService)
        {
            _portfolioClientService = portfolioClientService;
            _clientService = clientService;
            _clientTypeService = clientTypeService;
            _countryService = countryService;
            _genderService = genderService;
            _maritalStatusService = maritalStatusService;
            _occupationService = occupationService;
            _titleService = titleService;
        }

        // GET: PortfolioClients
        public async Task<IActionResult> Index(Guid portfolioId)
        {
            ClientResource resource = new ClientResource()
            {
                PortfolioId = portfolioId
            };

            return await Task.Run(() => View(resource)).ConfigureAwait(true);
        }

        // GET: PortfolioClients/Details/5
        public async Task<IActionResult> Details(Guid portfolioId, Guid clientId)
        {
            var portfolioClientId = await _portfolioClientService.GetPortfolioClientId(portfolioId, clientId);
            var resource = await _clientService.GetByClientId(portfolioId, clientId);
            if (resource == null)
            {
                return NotFound();
            }
            resource.PortfolioId = portfolioId;
            resource.PortfolioClientId = portfolioClientId;

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


            ClientSaveResource resource = new ClientSaveResource()
            {
                PortfolioId = portfolioId,
                ClientTypes = new SelectList(clientTypes, "Id", "Name"),
                Countries = new SelectList(countries, "Id", "Name"),
                Genders = new SelectList(genders, "Id", "Name"),
                MaritalStatuses = new SelectList(maritalStatuses, "Id", "Name"),
                Occupations = new SelectList(occupations, "Id", "Name"),
                Titles = new SelectList(titles, "Id", "Name")
            };
            return await Task.Run(() => View(resource)).ConfigureAwait(true);
        }

        // POST: PortfolioClients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

            resource.ClientTypes = new SelectList(clientTypes, "Id", "Name", resource.ClientTypeId);
            resource.Countries = new SelectList(countries, "Id", "Name", resource.CountryId);
            resource.Genders = new SelectList(genders, "Id", "Name", resource.GenderId);
            resource.MaritalStatuses = new SelectList(maritalStatuses, "Id", "Name", resource.MaritalStatusId);
            resource.Occupations = new SelectList(occupations, "Id", "Name", resource.OccupationId);
            resource.Titles = new SelectList(titles, "Id", "Name", resource.TitleId);

            return View(resource);
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
