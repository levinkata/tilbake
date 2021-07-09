using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;

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

        private readonly IMapper _mapper;

        public ClientsController(IClientService clientService,
                                IClientTypeService clientTypeService,
                                ICountryService countryService,
                                IGenderService genderService,
                                IMaritalStatusService maritalStatusService,
                                IOccupationService occupationService,
                                ITitleService titleService,
                                IMapper mapper)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
            _clientTypeService = clientTypeService ?? throw new ArgumentNullException(nameof(clientTypeService));
            _countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));
            _genderService = genderService ?? throw new ArgumentNullException(nameof(genderService));
            _maritalStatusService = maritalStatusService ?? throw new ArgumentNullException(nameof(maritalStatusService));
            _occupationService = occupationService ?? throw new ArgumentNullException(nameof(occupationService));
            _titleService = titleService ?? throw new ArgumentNullException(nameof(titleService));                                                                                    
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: ClientsController
        public async Task<IActionResult> Index()
        {
            //var result = await _clientService.GetAllAsync().ConfigureAwait(true);
            //var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>>(result);

            //return View(resources);
            return await Task.Run(() => View()).ConfigureAwait(true);
        }

        // GET: ClientsController/GetByPortfolio/5
        public async Task<IActionResult> GetByPortfolio(Guid portfolioId)
        {
            PortfolioResource resource = new PortfolioResource()
            {
                Id = portfolioId
            };
            
            return await Task.Run(() => View(resource)).ConfigureAwait(true);
        }

        // GET: ClientsController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var result = await _clientService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
            return View(clientResource);
        }

        // GET: ClientsController/Create
        public async Task<ActionResult> Create()
        {
            var clientTypes = await _clientTypeService.GetAllAsync();
            var countries = await _countryService.GetAllAsync();
            var genders = await _genderService.GetAllAsync();
            var maritalStatuses = await _maritalStatusService.GetAllAsync();
            var occupations = await _occupationService.GetAllAsync();
            var titles = await _titleService.GetAllAsync();                                                                        

            ClientSaveResource clientSaveResource = new ClientSaveResource()
            {
                ClientTypes = new SelectList(clientTypes, "Id", "Name"),
                Countries = new SelectList(countries, "Id", "Name"),
                Genders = new SelectList(genders, "Id", "Name"),
                MaritalStatuses = new SelectList(maritalStatuses, "Id", "Name"),
                Occupations = new SelectList(occupations, "Id", "Name"),
                Titles = new SelectList(titles, "Id", "Name")
            };

            return View(clientSaveResource);
        }

        // POST: ClientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClientSaveResource clientSaveResource)
        {
            if (clientSaveResource == null)
            {
                throw new ArgumentNullException(nameof(clientSaveResource));
            }

            if (ModelState.IsValid)
            {
                Client client = _mapper.Map<ClientSaveResource, Client>(clientSaveResource);
                client.Id = Guid.NewGuid();

                var result = await _clientService.AddAsync(client).ConfigureAwait(true);
                if (!result.Success)
                {
                    return BadRequest(new ErrorResource(result.Message));
                }
                return RedirectToAction(nameof(Index));
            }

            var clientTypes = await _clientTypeService.GetAllAsync();
            var countries = await _countryService.GetAllAsync();
            var genders = await _genderService.GetAllAsync();
            var maritalStatuses = await _maritalStatusService.GetAllAsync();
            var occupations = await _occupationService.GetAllAsync();
            var titles = await _titleService.GetAllAsync();

            clientSaveResource.ClientTypes = new SelectList(clientTypes, "Id", "Name", clientSaveResource.ClientTypeId);
            clientSaveResource.Countries = new SelectList(countries, "Id", "Name", clientSaveResource.CountryId);
            clientSaveResource.Genders = new SelectList(genders, "Id", "Name", clientSaveResource.GenderId);
            clientSaveResource.MaritalStatuses = new SelectList(maritalStatuses, "Id", "Name", clientSaveResource.MaritalStatusId);
            clientSaveResource.Occupations = new SelectList(occupations, "Id", "Name", clientSaveResource.OccupationId);
            clientSaveResource.Titles = new SelectList(titles, "Id", "Name", clientSaveResource.TitleId);

            return View(clientSaveResource);
        }

        // GET: ClientsController/AddToPortfolio/5
        public async Task<ActionResult> AddToPortfolio(Guid portfolioId)
        {
            var clientTypes = await _clientTypeService.GetAllAsync();
            var countries = await _countryService.GetAllAsync();
            var genders = await _genderService.GetAllAsync();
            var maritalStatuses = await _maritalStatusService.GetAllAsync();
            var occupations = await _occupationService.GetAllAsync();
            var titles = await _titleService.GetAllAsync();

            ClientSaveResource clientSaveResource = new ClientSaveResource()
            {
                PortfolioId = portfolioId,
                ClientTypes = new SelectList(clientTypes, "Id", "Name"),
                Countries = new SelectList(countries, "Id", "Name"),
                Genders = new SelectList(genders, "Id", "Name"),
                MaritalStatuses = new SelectList(maritalStatuses, "Id", "Name"),
                Occupations = new SelectList(occupations, "Id", "Name"),
                Titles = new SelectList(titles, "Id", "Name")
            };

            return View(clientSaveResource);
        }

        // POST: ClientsController/AddToPortfolio/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddToPortfolio(ClientSaveResource clientSaveResource)
        {
            if (clientSaveResource == null)
            {
                throw new ArgumentNullException(nameof(clientSaveResource));
            }

            if (ModelState.IsValid)
            {
                Client client = _mapper.Map<ClientSaveResource, Client>(clientSaveResource);
                client.Id = Guid.NewGuid();

                var result = await _clientService.AddToPortfolioAsync(clientSaveResource.PortfolioId, client).ConfigureAwait(true);
                if (!result.Success)
                {
                    return BadRequest(new ErrorResource(result.Message));
                }
                return RedirectToAction(nameof(GetByPortfolio), new { portfolioId = clientSaveResource.PortfolioId });
            }

            var clientTypes = await _clientTypeService.GetAllAsync();
            var countries = await _countryService.GetAllAsync();
            var genders = await _genderService.GetAllAsync();
            var maritalStatuses = await _maritalStatusService.GetAllAsync();
            var occupations = await _occupationService.GetAllAsync();
            var titles = await _titleService.GetAllAsync();

            clientSaveResource.ClientTypes = new SelectList(clientTypes, "Id", "Name", clientSaveResource.ClientTypeId);
            clientSaveResource.Countries = new SelectList(countries, "Id", "Name", clientSaveResource.CountryId);
            clientSaveResource.Genders = new SelectList(genders, "Id", "Name", clientSaveResource.GenderId);
            clientSaveResource.MaritalStatuses = new SelectList(maritalStatuses, "Id", "Name", clientSaveResource.MaritalStatusId);
            clientSaveResource.Occupations = new SelectList(occupations, "Id", "Name", clientSaveResource.OccupationId);
            clientSaveResource.Titles = new SelectList(titles, "Id", "Name", clientSaveResource.TitleId);

            return View(clientSaveResource);
        }

        // GET: ClientsController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var result = await _clientService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);

            var clientTypes = await _clientTypeService.GetAllAsync();
            var countries = await _countryService.GetAllAsync();
            var genders = await _genderService.GetAllAsync();
            var maritalStatuses = await _maritalStatusService.GetAllAsync();
            var occupations = await _occupationService.GetAllAsync();
            var titles = await _titleService.GetAllAsync();

            clientResource.ClientTypes = new SelectList(clientTypes, "Id", "Name", clientResource.ClientTypeId);
            clientResource.Countries = new SelectList(countries, "Id", "Name", clientResource.CountryId);
            clientResource.Genders = new SelectList(genders, "Id", "Name", clientResource.GenderId);
            clientResource.MaritalStatuses = new SelectList(maritalStatuses, "Id", "Name", clientResource.MaritalStatusId);
            clientResource.Occupations = new SelectList(occupations, "Id", "Name", clientResource.OccupationId);
            clientResource.Titles = new SelectList(titles, "Id", "Name", clientResource.TitleId);

            return View(clientResource);
        }

        // POST: ClientsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, ClientResource clientResource)
        {
            if (clientResource == null)
            {
                throw new ArgumentNullException(nameof(clientResource));
            }

            if (ModelState.IsValid)
            {
                Client client = _mapper.Map<ClientResource, Client>(clientResource);

                var result = await _clientService.UpdateAsync(id, client).ConfigureAwait(true);
                if (!result.Success)
                {
                    return BadRequest(new ErrorResource(result.Message));
                }
                return RedirectToAction(nameof(Index));
            }

            var clientTypes = await _clientTypeService.GetAllAsync();
            var countries = await _countryService.GetAllAsync();
            var genders = await _genderService.GetAllAsync();
            var maritalStatuses = await _maritalStatusService.GetAllAsync();
            var occupations = await _occupationService.GetAllAsync();
            var titles = await _titleService.GetAllAsync();

            clientResource.ClientTypes = new SelectList(clientTypes, "Id", "Name", clientResource.ClientTypeId);
            clientResource.Countries = new SelectList(countries, "Id", "Name", clientResource.CountryId);
            clientResource.Genders = new SelectList(genders, "Id", "Name", clientResource.GenderId);
            clientResource.MaritalStatuses = new SelectList(maritalStatuses, "Id", "Name", clientResource.MaritalStatusId);
            clientResource.Occupations = new SelectList(occupations, "Id", "Name", clientResource.OccupationId);
            clientResource.Titles = new SelectList(titles, "Id", "Name", clientResource.TitleId);

            return View(clientResource);
        }

        // GET: ClientsController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _clientService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
            return View(clientResource);
        }

        // POST: ClientsController/Delete/5
        [HttpPost]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var result = await _clientService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            try
            {
                var deleteResult = await _clientService.DeleteAsync(id).ConfigureAwait(true);
                if (!deleteResult.Success)
                {
                    return BadRequest(new ErrorResource(result.Message));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
                return View(clientResource);
            }
        }
    }
}
