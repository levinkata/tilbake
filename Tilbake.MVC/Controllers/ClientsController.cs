using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Helpers;
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

        [HttpGet]
        public async Task<IActionResult> GetByIdNumber(string idNumber)
        {
            var result = await _unitOfWork.Clients.GetByIdNumber(idNumber);
            if(result != null)
            {
                var model = _mapper.Map<Client, ClientViewModel>(result);
                return Json(new { model.Id, model.FirstName, model.LastName, model.IdNumber, model.ClientNumber });
            }

            return Json(result);
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

            var cityId = model.Address.CityId;
            var city = await _unitOfWork.Cities.GetById(cityId);
            var countryId = city.CountryId;

            var carriers = await _unitOfWork.Carriers.GetAll(r => r.OrderBy(n => n.Name));
            var cities = await _unitOfWork.Cities.GetByCountryId(countryId);
            var clientTypes = await _unitOfWork.ClientTypes.GetAll(r => r.OrderBy(n => n.Name));
            var clientStatuses = await _unitOfWork.ClientStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var countries = await _unitOfWork.Countries.GetAll(r => r.OrderBy(n => n.Name));
            var genders = await _unitOfWork.Genders.GetAll(r => r.OrderBy(n => n.Name));
            var idDocumentTypes = await _unitOfWork.IdDocumentTypes.GetAll(r => r.OrderBy(n => n.Name));
            var maritalStatuses = await _unitOfWork.MaritalStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var occupations = await _unitOfWork.Occupations.GetAll(r => r.OrderBy(n => n.Name));
            var titles = await _unitOfWork.Titles.GetAll(r => r.OrderBy(n => n.Name));

            model.CountryList = MVCHelperExtensions.ToSelectList(countries, model.CountryId);
            model.ClientTypeList = MVCHelperExtensions.ToSelectList(clientTypes, model.ClientTypeId);
            model.CountryList = MVCHelperExtensions.ToSelectList(countries, model.CountryId);
            model.GenderList = MVCHelperExtensions.ToSelectList(genders, model.GenderId);
            model.IdDocumentTypeList = MVCHelperExtensions.ToSelectList(idDocumentTypes, model.IdDocumentTypeId);
            model.MaritalStatusList = MVCHelperExtensions.ToSelectList(maritalStatuses, model.MaritalStatusId);
            model.OccupationList = MVCHelperExtensions.ToSelectList(occupations, model.OccupationId);
            model.TitleList = MVCHelperExtensions.ToSelectList(titles, model.TitleId);

            model.CarrierList = MVCHelperExtensions.ToMultiSelectList(carriers, model.CarrierIds);

            model.AddressCountryList = MVCHelperExtensions.ToSelectList(countries, countryId);
            model.CityList = MVCHelperExtensions.ToSelectList(cities, cityId);
            return View(model);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = _mapper.Map<ClientViewModel, Client>(model);
                _unitOfWork.Clients.Update(model.Id, client);

                var clientId = client.Id;
                var clientCarriers = await _unitOfWork.ClientCarriers.Get(r => r.ClientId == clientId);

                if (clientCarriers != null)
                {
                    _unitOfWork.ClientCarriers.DeleteRange(clientCarriers);
                }

                var newClientCarriers = new List<ClientCarrier>();

                foreach (var item in model.CarrierIds)
                {
                    ClientCarrier clientCarrier = new()
                    {
                        ClientId = clientId,
                        CarrierId = item
                    };
                    newClientCarriers.Add(clientCarrier);
                }
                _unitOfWork.ClientCarriers.AddRange(newClientCarriers);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }

            var carriers = await _unitOfWork.Carriers.GetAll(r => r.OrderBy(n => n.Name));
            var cities = await _unitOfWork.Cities.GetByCountryId(model.CountryId);
            var clientTypes = await _unitOfWork.ClientTypes.GetAll(r => r.OrderBy(n => n.Name));
            var clientStatuses = await _unitOfWork.ClientStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var countries = await _unitOfWork.Countries.GetAll(r => r.OrderBy(n => n.Name));
            var genders = await _unitOfWork.Genders.GetAll(r => r.OrderBy(n => n.Name));
            var idDocumentTypes = await _unitOfWork.IdDocumentTypes.GetAll(r => r.OrderBy(n => n.Name));
            var maritalStatuses = await _unitOfWork.MaritalStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var occupations = await _unitOfWork.Occupations.GetAll(r => r.OrderBy(n => n.Name));
            var titles = await _unitOfWork.Titles.GetAll(r => r.OrderBy(n => n.Name));

            model.CountryList = MVCHelperExtensions.ToSelectList(countries, model.CountryId);
            model.ClientTypeList = MVCHelperExtensions.ToSelectList(clientTypes, model.ClientTypeId);
            model.CountryList = MVCHelperExtensions.ToSelectList(countries, model.CountryId);
            model.GenderList = MVCHelperExtensions.ToSelectList(genders, model.GenderId);
            model.IdDocumentTypeList = MVCHelperExtensions.ToSelectList(idDocumentTypes, model.IdDocumentTypeId);
            model.MaritalStatusList = MVCHelperExtensions.ToSelectList(maritalStatuses, model.MaritalStatusId);
            model.OccupationList = MVCHelperExtensions.ToSelectList(occupations, model.OccupationId);
            model.TitleList = MVCHelperExtensions.ToSelectList(titles, model.TitleId);

            model.CarrierList = MVCHelperExtensions.ToMultiSelectList(carriers, model.CarrierIds);

            model.Address.CountryList = MVCHelperExtensions.ToSelectList(countries, model.Address.CountryId);
            model.Address.CityList = MVCHelperExtensions.ToSelectList(cities, model.Address.CityId);

            return View(model);
        }
    }
}
