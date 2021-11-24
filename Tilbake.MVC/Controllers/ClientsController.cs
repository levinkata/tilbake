using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Core;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class ClientsController : BaseController
    {
        public ClientsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Clients.GetAll(r => r.OrderBy(n => n.LastName));
            var model = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(result);
            return View(model);
        }

        public async Task<IActionResult> Search(string searchString = "~#")
        {
            var result = await _unitOfWork.Clients.GetAll(r => r.OrderBy(n => n.LastName));
            var clientModel = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(result);

            if (!String.IsNullOrEmpty(searchString))
            {
                clientModel = clientModel.Where(r => r.LastName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                        || r.FirstName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                        || r.IdNumber.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
            }

            ClientSearchViewModel model = new()
            {
                SearchString = "",
                ClientViewModels = clientModel
            };
            return View(model);
        }

        // GET: Clients/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.Clients.GetById(id);            
            if (result == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<Client, ClientViewModel>(result);
            return View(model);
        }

        // GET: Clients/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.Clients.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<Client, ClientViewModel>(result);

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
    }
}
