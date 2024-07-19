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
    public class CustomersController : BaseController
    {
        public CustomersController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Customers.GetAll(r => r.OrderBy(n => n.LastName));
            var model = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(result);
            return View(model);
        }

        public async Task<IActionResult> Search(string searchString = "~#")
        {
            var result = await _unitOfWork.Customers.GetAll(r => r.OrderBy(n => n.LastName));
            var customerModel = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(result);

            if (!String.IsNullOrEmpty(searchString))
            {
                customerModel = customerModel.Where(r => r.LastName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                        || r.FirstName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                        || r.IdNumber.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
            }

            CustomerSearchViewModel model = new()
            {
                SearchString = "",
                CustomerViewModels = customerModel
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdNumber(string idNumber)
        {
            var result = await _unitOfWork.Customers.GetByIdNumber(idNumber);
            if(result != null)
            {
                var model = _mapper.Map<Customer, CustomerViewModel>(result);
                return Json(new { model.Id, model.FirstName, model.LastName, model.IdNumber, model.CustomerNumber });
            }

            return Json(result);
        }

        // GET: Customers/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.Customers.GetById(id);            
            if (result == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<Customer, CustomerViewModel>(result);
            return View(model);
        }

        // GET: Customers/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.Customers.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<Customer, CustomerViewModel>(result);

            //var cityId = model.Address.CityId;
            //var city = await _unitOfWork.Cities.GetById(cityId);
            //var countryId = city.CountryId;

            var carriers = await _unitOfWork.Carriers.GetAll(r => r.OrderBy(n => n.Name));
            //var cities = await _unitOfWork.Cities.GetByCountryId(countryId);
            var customerTypes = await _unitOfWork.CustomerTypes.GetAll(r => r.OrderBy(n => n.Name));
            var customerStatuses = await _unitOfWork.CustomerStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var countries = await _unitOfWork.Countries.GetAll(r => r.OrderBy(n => n.Name));
            var genders = await _unitOfWork.Genders.GetAll(r => r.OrderBy(n => n.Name));
            var idDocumentTypes = await _unitOfWork.IdDocumentTypes.GetAll(r => r.OrderBy(n => n.Name));
            var maritalStatuses = await _unitOfWork.MaritalStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var occupations = await _unitOfWork.Occupations.GetAll(r => r.OrderBy(n => n.Name));
            var titles = await _unitOfWork.Titles.GetAll(r => r.OrderBy(n => n.Name));

            model.CountryList = MVCHelperExtensions.ToSelectList(countries, model.CountryId);
            model.CustomerTypeList = MVCHelperExtensions.ToSelectList(customerTypes, model.CustomerTypeId);
            model.CountryList = MVCHelperExtensions.ToSelectList(countries, model.CountryId);
            model.GenderList = MVCHelperExtensions.ToSelectList(genders, model.GenderId);
            model.IdDocumentTypeList = MVCHelperExtensions.ToSelectList(idDocumentTypes, model.IdDocumentTypeId);
            model.MaritalStatusList = MVCHelperExtensions.ToSelectList(maritalStatuses, model.MaritalStatusId);
            model.OccupationList = MVCHelperExtensions.ToSelectList(occupations, model.OccupationId);
            model.TitleList = MVCHelperExtensions.ToSelectList(titles, model.TitleId);

            model.CarrierList = MVCHelperExtensions.ToMultiSelectList(carriers, model.CarrierIds);

            //model.AddressCountryList = MVCHelperExtensions.ToSelectList(countries, countryId);
            //model.CityList = MVCHelperExtensions.ToSelectList(cities, cityId);
            return View(model);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<CustomerViewModel, Customer>(model);
                _unitOfWork.Customers.Update(model.Id, customer);

                var customerId = customer.Id;
                var customerCarriers = await _unitOfWork.CustomerCarriers.Get(r => r.CustomerId == customerId);

                if (customerCarriers != null)
                {
                    _unitOfWork.CustomerCarriers.DeleteRange(customerCarriers);
                }

                var newCustomerCarriers = new List<CustomerCarrier>();

                foreach (var item in model.CarrierIds)
                {
                    CustomerCarrier customerCarrier = new()
                    {
                        CustomerId = customerId,
                        CarrierId = item
                    };
                    newCustomerCarriers.Add(customerCarrier);
                }
                _unitOfWork.CustomerCarriers.AddRange(newCustomerCarriers);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }

            var carriers = await _unitOfWork.Carriers.GetAll(r => r.OrderBy(n => n.Name));
            var cities = await _unitOfWork.Cities.GetByCountryId(model.CountryId);
            var customerTypes = await _unitOfWork.CustomerTypes.GetAll(r => r.OrderBy(n => n.Name));
            var customerStatuses = await _unitOfWork.CustomerStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var countries = await _unitOfWork.Countries.GetAll(r => r.OrderBy(n => n.Name));
            var genders = await _unitOfWork.Genders.GetAll(r => r.OrderBy(n => n.Name));
            var idDocumentTypes = await _unitOfWork.IdDocumentTypes.GetAll(r => r.OrderBy(n => n.Name));
            var maritalStatuses = await _unitOfWork.MaritalStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var occupations = await _unitOfWork.Occupations.GetAll(r => r.OrderBy(n => n.Name));
            var titles = await _unitOfWork.Titles.GetAll(r => r.OrderBy(n => n.Name));

            model.CountryList = MVCHelperExtensions.ToSelectList(countries, model.CountryId);
            model.CustomerTypeList = MVCHelperExtensions.ToSelectList(customerTypes, model.CustomerTypeId);
            model.CountryList = MVCHelperExtensions.ToSelectList(countries, model.CountryId);
            model.GenderList = MVCHelperExtensions.ToSelectList(genders, model.GenderId);
            model.IdDocumentTypeList = MVCHelperExtensions.ToSelectList(idDocumentTypes, model.IdDocumentTypeId);
            model.MaritalStatusList = MVCHelperExtensions.ToSelectList(maritalStatuses, model.MaritalStatusId);
            model.OccupationList = MVCHelperExtensions.ToSelectList(occupations, model.OccupationId);
            model.TitleList = MVCHelperExtensions.ToSelectList(titles, model.TitleId);

            model.CarrierList = MVCHelperExtensions.ToMultiSelectList(carriers, model.CarrierIds);

            //model.Address.CountryList = MVCHelperExtensions.ToSelectList(countries, model.Address.CountryId);
            //model.Address.CityList = MVCHelperExtensions.ToSelectList(cities, model.Address.CityId);

            return View(model);
        }
    }
}
