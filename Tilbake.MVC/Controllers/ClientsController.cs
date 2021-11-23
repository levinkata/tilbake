using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IClientTypeService _clientTypeService;
        private readonly IClientStatusService _clientStatusService;
        private readonly ICountryService _countryService;
        private readonly IGenderService _genderService;
        private readonly IMaritalStatusService _maritalStatusService;
        private readonly IOccupationService _occupationService;
        private readonly ITitleService _titleService;
        private readonly ICarrierService _carrierService;

        public ClientsController(IClientService clientService,
                                IClientTypeService clientTypeService,
                                IClientStatusService clientStatusService,
                                ICountryService countryService,
                                IGenderService genderService,
                                IMaritalStatusService maritalStatusService,
                                IOccupationService occupationService,
                                ITitleService titleService,
                                ICarrierService carrierService)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
            _clientTypeService = clientTypeService ?? throw new ArgumentNullException(nameof(clientTypeService));
            _clientStatusService = clientStatusService ?? throw new ArgumentNullException(nameof(clientStatusService));
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

        public async Task<IActionResult> Search(string searchString = "~#")
        {
            var ViewModels = await _clientService.GetAllAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                ViewModels = ViewModels.Where(r => r.LastName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                        || r.FirstName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                        || r.IdNumber.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
            }

            ClientSearchViewModel searchViewModel = new()
            {
                SearchString = "",
                ClientViewModels = ViewModels.ToList()
            };
            return View(searchViewModel);
        }

        // GET: Clients/GetByPortfolio/5
        public async Task<IActionResult> GetByPortfolio(Guid portfolioId)
        {
            PortfolioViewModel ViewModel = new()
            {
                Id = portfolioId
            };
            
            return await Task.Run(() => View(ViewModel));
        }

        public async Task<IActionResult> GetByIdNumber(string idNumber)
        {
            var ViewModel = await _clientService.GetByIdNumberAsync(idNumber);
            return Json(ViewModel);
        }

        // GET: Clients/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _clientService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // GET: Clients/Create
        // public async Task<ActionResult> Create()
        // {
        //     var clientTypes = await _clientTypeService.GetAllAsync();
        //     var countries = await _countryService.GetAllAsync();
        //     var genders = await _genderService.GetAllAsync();
        //     var maritalStatuses = await _maritalStatusService.GetAllAsync();
        //     var occupations = await _occupationService.GetAllAsync();
        //     var titles = await _titleService.GetAllAsync();

        //     PortfolioClientViewModel ViewModel = new()
        //     {
        //         ClientTypeList = new SelectList(clientTypes, "Id", "Name"),
        //         CountryList = new SelectList(countries, "Id", "Name"),
        //         GenderList = new SelectList(genders, "Id", "Name"),
        //         MaritalStatusList = new SelectList(maritalStatuses, "Id", "Name"),
        //         OccupationList = new SelectList(occupations, "Id", "Name"),
        //         TitleList = new SelectList(titles, "Id", "Name")
        //     };

        //     return View(ViewModel);
        // }

        // POST: Clients/Create
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<ActionResult> Create(PortfolioClientViewModel ViewModel)
        // {
        //     if (ViewModel == null)
        //     {
        //         throw new ArgumentNullException(nameof(ViewModel));
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         await _clientService.AddAsync(ViewModel);
        //         return RedirectToAction(nameof(Index));
        //     }

        //     var clientTypes = await _clientTypeService.GetAllAsync();
        //     var countries = await _countryService.GetAllAsync();
        //     var genders = await _genderService.GetAllAsync();
        //     var maritalStatuses = await _maritalStatusService.GetAllAsync();
        //     var occupations = await _occupationService.GetAllAsync();
        //     var titles = await _titleService.GetAllAsync();

        //     ViewModel.ClientTypeList = new SelectList(clientTypes, "Id", "Name", ViewModel.ClientTypeId);
        //     ViewModel.CountryList = new SelectList(countries, "Id", "Name", ViewModel.CountryId);
        //     ViewModel.GenderList = new SelectList(genders, "Id", "Name", ViewModel.GenderId);
        //     ViewModel.MaritalStatusList = new SelectList(maritalStatuses, "Id", "Name", ViewModel.MaritalStatusId);
        //     ViewModel.OccupationList = new SelectList(occupations, "Id", "Name", ViewModel.OccupationId);
        //     ViewModel.TitleList = new SelectList(titles, "Id", "Name", ViewModel.TitleId);

        //     return View(ViewModel);
        // }

        // GET: Clients/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var ViewModel = await _clientService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            var clientTypes = await _clientTypeService.GetAllAsync();
            var countries = await _countryService.GetAllAsync();
            var genders = await _genderService.GetAllAsync();
            var maritalStatuses = await _maritalStatusService.GetAllAsync();
            var occupations = await _occupationService.GetAllAsync();
            var titles = await _titleService.GetAllAsync();

            ViewModel.ClientTypeList = new SelectList(clientTypes, "Id", "Name", ViewModel.ClientTypeId);
            ViewModel.CountryList = new SelectList(countries, "Id", "Name", ViewModel.CountryId);
            ViewModel.GenderList = new SelectList(genders, "Id", "Name", ViewModel.GenderId);
            ViewModel.MaritalStatusList = new SelectList(maritalStatuses, "Id", "Name", ViewModel.MaritalStatusId);
            ViewModel.OccupationList = new SelectList(occupations, "Id", "Name", ViewModel.OccupationId);
            ViewModel.TitleList = new SelectList(titles, "Id", "Name", ViewModel.TitleId);

            return View(ViewModel);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, ClientViewModel ViewModel)
        {
            if (ViewModel == null)
            {
                throw new ArgumentNullException(nameof(ViewModel));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _clientService.UpdateAsync(ViewModel);
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

            ViewModel.ClientTypeList = new SelectList(clientTypes, "Id", "Name", ViewModel.ClientTypeId);
            ViewModel.CountryList = new SelectList(countries, "Id", "Name", ViewModel.CountryId);
            ViewModel.GenderList = new SelectList(genders, "Id", "Name", ViewModel.GenderId);
            ViewModel.MaritalStatusList = new SelectList(maritalStatuses, "Id", "Name", ViewModel.MaritalStatusId);
            ViewModel.OccupationList = new SelectList(occupations, "Id", "Name", ViewModel.OccupationId);
            ViewModel.TitleList = new SelectList(titles, "Id", "Name", ViewModel.TitleId);

            return View(ViewModel);
        }

        // GET: Clients/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _clientService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // POST: Clients/Delete/5
        [HttpPost]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clientService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
