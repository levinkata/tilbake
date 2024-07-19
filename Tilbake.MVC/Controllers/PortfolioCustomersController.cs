using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core;
using Tilbake.Core.Enums;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Helpers;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class PortfolioCustomersController : BaseController
    {
        public PortfolioCustomersController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Search(Guid portfolioId, string searchString = "~#")
        {
            var portfolio = await _unitOfWork.Portfolios.GetById(portfolioId);
            var customers = await _unitOfWork.PortfolioCustomers.GetByPortfolioId(portfolioId);

            var customerModel = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);

            if (!String.IsNullOrEmpty(searchString) && portfolioId != Guid.Empty)
            {
                customerModel = customerModel.Where(r => r.LastName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                        || r.FirstName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                        || r.IdNumber.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
            }

            PortfolioCustomerSearchViewModel model = new()
            {
                PortfolioId = portfolioId,
                PortfolioName = portfolio.Name,
                SearchString = "",
                Customers = customerModel
            };
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> CreateWizard(Guid portfolioId)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var result = await _unitOfWork.ApplicationSessions.GetByUserId(user.Id);

            PortfolioCustomerViewModel model = new()
            {
                PortfolioId = Guid.Parse(result.FirstOrDefault(n => n.Name == "PortfolioId").Value)
            };
            CustomerViewModel customerModel = new()
            {
                PortfolioName = result.FirstOrDefault(n => n.Name == "PortfolioName").Value
            };
            model.Customer = customerModel;

            return View(model);
        }

        public async Task<IActionResult> ImportBulk(Guid portfolioId, Guid fileTemplateId, FileType fileType, string delimiter)
        {
            var result = await _unitOfWork.Portfolios.GetById(portfolioId);

            UpLoadFileViewModel ViewModel = new()
            {
                PortfolioId = portfolioId,
                PortfolioName = result.Name,
                FileTemplateId = fileTemplateId,
                FileType = fileType,
                Delimiter = delimiter,
                TableName = "Customer"
            };
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportBulk(UpLoadFileViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            };

            if (ModelState.IsValid)
            {
                //await _customerService.ImportBulkAsync(ViewModel);
                return RedirectToAction(nameof(LoadBulks), new { model.PortfolioId });
            }

            return View(model);
        }

        public async Task<IActionResult> LoadBulks(Guid portfolioId)
        {
            //var ViewModels = await _customerService.GetBulkByPortfolioIdAsync(portfolioId);
            var portfolio = await _unitOfWork.Portfolios.GetByIdAsync(portfolioId);

            ViewBag.PortfolioId = portfolioId;
            ViewBag.PortfolioName = portfolio.Name;

            return View();
        }

        [HttpPost, ActionName("LoadBulks")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoadConfirmed(List<CustomerBulkViewModel> model)
        {
            var portfolioId = model.GroupBy(r => r.PortfolioId).FirstOrDefault().Key;
            var portfolio = await _unitOfWork.Portfolios.GetByIdAsync((Guid)portfolioId);

            if (ModelState.IsValid)
            {
                //await _customerService.AddBulkAsync((Guid)portfolioId);
                return RedirectToAction(nameof(Index), new { portfolioId });
            }
            else
            {
                ModelState.AddModelError("", "Encountered possible error - Model is invalid");
                ViewBag.PortfolioId = portfolioId;
                ViewBag.PortfolioName = portfolio.Name;
                return View(model);
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> GetPortfolioCustomers(Guid portfolioId, string category, string searchString)
        //{
            //var result = await _customerService.GetByPortfolioIdAsync(portfolioId);

            //switch (category)
            //{
            //    case "Customer Number":
            //        bool isNumber = int.TryParse(searchString, out int n);
            //        if (isNumber)
            //        {
            //            result = result.Where(r => r.CustomerNumber == n);
            //        }
            //        break;
            //    case "Id Number":
            //        result = result.Where(r => r.IdNumber == searchString);
            //        break;
            //    case "Name":
            //        if (!String.IsNullOrEmpty(searchString))
            //        {
            //            result = result.Where(r => r.LastName.Contains(searchString)
            //                                    || r.FirstName.Contains(searchString));
            //        }
            //        break;
            //    default:
            //        break;
            //}
        //    return Json(Ok);
        //}

        public async Task<IActionResult> Details(Guid portfolioId, Guid customerId)
        {
            var result = await _unitOfWork.PortfolioCustomers.GetByPortfolioIdAndCustomerId(portfolioId, customerId);
            var model = _mapper.Map<Customer, CustomerViewModel>(result);

            var cityId = model.Addresses.FirstOrDefault().CityId;
            var city = await _unitOfWork.Cities.GetById(cityId);
            var countryId = city.CountryId;

            var carriers = await _unitOfWork.Carriers.GetAll(r => r.OrderBy(n => n.Name));
            var cities = await _unitOfWork.Cities.GetByCountryId(countryId);
            var customerTypes = await _unitOfWork.CustomerTypes.GetAll(r => r.OrderBy(n => n.Name));
            var customerStatuses = await _unitOfWork.CustomerStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var countries = await _unitOfWork.Countries.GetAll(r => r.OrderBy(n => n.Name));
            var genders = await _unitOfWork.Genders.GetAll(r => r.OrderBy(n => n.Name));
            var idDocumentTypes = await _unitOfWork.IdDocumentTypes.GetAll(r => r.OrderBy(n => n.Name));
            var maritalStatuses = await _unitOfWork.MaritalStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var occupations = await _unitOfWork.Occupations.GetAll(r => r.OrderBy(n => n.Name));
            var titles = await _unitOfWork.Titles.GetAll(r => r.OrderBy(n => n.Name));

            model.PortfolioId = portfolioId;
            model.PortfolioName = model.PortfolioName;
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

        // GET: PortfolioCustomers/Create
        public async Task<IActionResult> Create(Guid portfolioId)
        {
            var carriers = await _unitOfWork.Carriers.GetAll(r => r.OrderBy(n => n.Name));
            var customerTypes = await _unitOfWork.CustomerTypes.GetAll(r => r.OrderBy(n => n.Name));
            var customerStatuses = await _unitOfWork.CustomerStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var countries = await _unitOfWork.Countries.GetAll(r => r.OrderBy(n => n.Name));
            var genders = await _unitOfWork.Genders.GetAll(r => r.OrderBy(n => n.Name));
            var idDocumentTypes = await _unitOfWork.IdDocumentTypes.GetAll(r => r.OrderBy(n => n.Name));
            var maritalStatuses = await _unitOfWork.MaritalStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var occupations = await _unitOfWork.Occupations.GetAll(r => r.OrderBy(n => n.Name));
            var titles = await _unitOfWork.Titles.GetAll(r => r.OrderBy(n => n.Name));

            var portfolio = await _unitOfWork.Portfolios.GetById(portfolioId);

            PortfolioCustomerViewModel model = new()
            {
                PortfolioId = portfolioId,
                CustomerStatusList = MVCHelperExtensions.ToSelectList(customerStatuses, Guid.Empty)
            };

            //AddressViewModel addressViewModel = new()
            //{
            //    CountryList = MVCHelperExtensions.ToSelectList(countries, Guid.Empty)
            //};

            CustomerViewModel customerViewModel = new()
            {
                PortfolioName = portfolio.Name,
                BirthDate = DateTime.Now.Date,

                CustomerTypeList = MVCHelperExtensions.ToSelectList(customerTypes, Guid.Empty),
                CountryList = MVCHelperExtensions.ToSelectList(countries, Guid.Empty),
                GenderList = MVCHelperExtensions.ToSelectList(genders, Guid.Empty),
                IdDocumentTypeList = MVCHelperExtensions.ToSelectList(idDocumentTypes, Guid.Empty),
                MaritalStatusList = MVCHelperExtensions.ToSelectList(maritalStatuses, Guid.Empty),
                OccupationList = MVCHelperExtensions.ToSelectList(occupations, Guid.Empty),
                TitleList = MVCHelperExtensions.ToSelectList(titles, Guid.Empty)
            };

            customerViewModel.CarrierList = MVCHelperExtensions.ToMultiSelectList(carriers, customerViewModel.CarrierIds);
            //customerViewModel.Addresses = addressViewModel;
            model.Customer = customerViewModel;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customerViewModel = model.Customer;
                Guid customerId = Guid.NewGuid();

                var customer = _mapper.Map<CustomerViewModel, Customer>(customerViewModel);

                if (customer != null)
                {
                    customer.Id = customerId;
                    customer.DateAdded = DateTime.Now;

                    customerId = customer.Id;

                    var portfolioCustomer = _mapper.Map<PortfolioCustomerViewModel, PortfolioCustomer>(model);

                    portfolioCustomer.Id = Guid.NewGuid();
                    portfolioCustomer.CustomerId = customerId;
                    portfolioCustomer.DateAdded = DateTime.Now;

                    customer.PortfolioCustomers.Add(portfolioCustomer);
                    await _unitOfWork.Customers.Add(customer);

                    //var addressViewModel = model.Customer.Address;

                    //if (addressViewModel != null)
                    //{
                    //    var address = _mapper.Map<AddressViewModel, Address>(addressViewModel);

                    //    address.Id = Guid.NewGuid();
                    //    address.CustomerId = customerId;
                    //    address.DateAdded = DateTime.Now;
                    //    await _unitOfWork.Addresses.Add(address);
                    //}

                    var emailAddressesViewModels = model.Customer.EmailAddresses;
                    if (emailAddressesViewModels.Count > 0)
                    {
                        var emailAddresses = _mapper.Map<IEnumerable<EmailAddressViewModel>, IEnumerable<EmailAddress>>(emailAddressesViewModels);

                        foreach (var emailAddress in emailAddresses)
                        {
                            emailAddress.Id = Guid.NewGuid();
                            emailAddress.CustomerId = customerId;
                            emailAddress.DateAdded = DateTime.Now;
                            await _unitOfWork.EmailAddresses.Add(emailAddress);
                        }
                    }

                    var mobileNumbersViewModels = model.Customer.MobileNumbers;
                    if (mobileNumbersViewModels.Count > 0)
                    {
                        var mobileNumbers = _mapper.Map<IEnumerable<MobileNumberViewModel>, IEnumerable<MobileNumber>>(mobileNumbersViewModels);
                        foreach (var mobileNumber in mobileNumbers)
                        {
                            mobileNumber.Id = Guid.NewGuid();
                            mobileNumber.CustomerId = customerId;
                            mobileNumber.DateAdded = DateTime.Now;
                            await _unitOfWork.MobileNumbers.Add(mobileNumber);
                        }
                    }

                    var carrierIds = model.Customer.CarrierIds;
                    if (carrierIds != null)
                    {
                        foreach (var carrierId in carrierIds)
                        {
                            CustomerCarrier newCustomerCarrier = new()
                            {
                                CustomerId = customerId,
                                CarrierId = carrierId,
                                DateAdded = DateTime.Now
                            };
                            await _unitOfWork.CustomerCarriers.Add(newCustomerCarrier);
                        }
                    }
                    await _unitOfWork.CompleteAsync();

                }
                return RedirectToAction(nameof(Search), new { portfolioId = model.PortfolioId, searchString = model.Customer.LastName });
            }

            var countryId = model.Customer.CountryId;
            var carriers = await _unitOfWork.Carriers.GetAll(r => r.OrderBy(n => n.Name));
            var cities = await _unitOfWork.Cities.GetByCountryId(countryId);
            var customerTypes = await _unitOfWork.CustomerTypes.GetAll(r => r.OrderBy(n => n.Name));
            var customerStatuses = await _unitOfWork.CustomerStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var countries = await _unitOfWork.Countries.GetAll(r => r.OrderBy(n => n.Name));
            var genders = await _unitOfWork.Genders.GetAll(r => r.OrderBy(n => n.Name));
            var idDocumentTypes = await _unitOfWork.IdDocumentTypes.GetAll(r => r.OrderBy(n => n.Name));
            var maritalStatuses = await _unitOfWork.MaritalStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var occupations = await _unitOfWork.Occupations.GetAll(r => r.OrderBy(n => n.Name));
            var titles = await _unitOfWork.Titles.GetAll(r => r.OrderBy(n => n.Name));

            var portfolio = await _unitOfWork.Portfolios.GetById(model.PortfolioId);

            model.CustomerStatusList = MVCHelperExtensions.ToSelectList(customerStatuses, model.CustomerStatusId);
            model.Customer.CountryList = MVCHelperExtensions.ToSelectList(countries, model.Customer.CountryId);
            model.Customer.CustomerTypeList = MVCHelperExtensions.ToSelectList(customerTypes, model.Customer.CustomerTypeId);
            model.Customer.CountryList = MVCHelperExtensions.ToSelectList(countries, model.Customer.CountryId);
            model.Customer.GenderList = MVCHelperExtensions.ToSelectList(genders, model.Customer.GenderId);
            model.Customer.IdDocumentTypeList = MVCHelperExtensions.ToSelectList(idDocumentTypes, model.Customer.IdDocumentTypeId);
            model.Customer.MaritalStatusList = MVCHelperExtensions.ToSelectList(maritalStatuses, model.Customer.MaritalStatusId);
            model.Customer.OccupationList = MVCHelperExtensions.ToSelectList(occupations, model.Customer.OccupationId);
            model.Customer.TitleList = MVCHelperExtensions.ToSelectList(titles, model.Customer.TitleId);
            model.Customer.CarrierList = MVCHelperExtensions.ToMultiSelectList(carriers, model.Customer.CarrierIds);

            //model.Customer.AddressCountryList = MVCHelperExtensions.ToSelectList(countries, countryId);
            //model.Customer.CityList = MVCHelperExtensions.ToSelectList(cities, model.Customer.Address.CityId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddExistingCustomer(Guid portfolioId, Guid customerId)
        {
            PortfolioCustomer newPortfolioCustomer = new()
            {
                Id = Guid.NewGuid(),
                PortfolioId = portfolioId,
                CustomerId = customerId,
                CustomerStatusId = Guid.Parse(Constants.DefaultCustomerStatusId),
                DateAdded = DateTime.Now
            };
;
            await _unitOfWork.PortfolioCustomers.Add(newPortfolioCustomer);
            await _unitOfWork.CompleteAsync();
            return Json(new { portfolioId, customerId });
        }

        [HttpGet]
        public async Task<IActionResult> GetByPortfolioIdAndIdNumber(Guid portfolioId, string idNumber)
        {
            var result = await _unitOfWork.PortfolioCustomers.GetByPortfolioIdAndIdNumber(portfolioId, idNumber);
            var model = _mapper.Map<Customer, CustomerViewModel>(result);
            return Json(model);
        }

        [HttpGet] 
        public async Task<IActionResult> Edit(Guid portfolioId, Guid customerId)
        {
            var result = await _unitOfWork.PortfolioCustomers.GetByPortfolioIdAndCustomerId(portfolioId, customerId);
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

            model.PortfolioId = portfolioId;
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

            return View("EditCustomer", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerViewModel model)
        {
            if(ModelState.IsValid)
            {
                var customer = _mapper.Map<CustomerViewModel, Customer>(model);
                
                customer.DateModified = DateTime.Now;
                await _unitOfWork.Customers.Update(customer);

                var customerId = customer.Id;
                //var addressViewModel = model.Address;
                //var address = _mapper.Map<AddressViewModel, Address>(addressViewModel);

                //address.CustomerId = customerId;
                //address.DateAdded = DateTime.Now;
                //await _unitOfWork.Addresses.Update(address);

                var emailAddressesViewModels = model.EmailAddresses;
                var emailAddresses = _mapper.Map<IEnumerable<EmailAddressViewModel>, IEnumerable<EmailAddress>>(emailAddressesViewModels);

                foreach (var emailAddress in emailAddresses)
                {
                    emailAddress.CustomerId = customerId;
                    emailAddress.DateModified = DateTime.Now;
                    await _unitOfWork.EmailAddresses.Update(emailAddress);
                }

                var mobileNumbersViewModels = model.MobileNumbers;
                var mobileNumbers = _mapper.Map<IEnumerable<MobileNumberViewModel>, IEnumerable<MobileNumber>>(mobileNumbersViewModels);
                foreach (var mobileNumber in mobileNumbers)
                {
                    mobileNumber.CustomerId = customerId;
                    mobileNumber.DateModified = DateTime.Now;
                    await _unitOfWork.MobileNumbers.Update(mobileNumber);
                }
                
                var carrierIds = model.CarrierIds;
                var customerCarriers = await _unitOfWork.CustomerCarriers.GetByCustomerId(customerId);

                _unitOfWork.CustomerCarriers.DeleteRange(customerCarriers);

                if (carrierIds != null)
                {
                    List<CustomerCarrier> newCustomerCarriers = new();

                    foreach (var carrierId in carrierIds)
                    {
                        CustomerCarrier newCustomerCarrier = new()
                        {
                            CustomerId = customerId,
                            CarrierId = carrierId,
                            DateAdded = DateTime.Now
                        };
                        newCustomerCarriers.Add(newCustomerCarrier);
                    }
                    _unitOfWork.CustomerCarriers.AddRange(newCustomerCarriers);
                }
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Edit), new { portfolioId = model.PortfolioId, customerId = model.Id });
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

            return View("EditCustomer", model);
        }

        // GET: PortfolioCustomers/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.PortfolioCustomers.GetById(id);
            var model = _mapper.Map<PortfolioCustomer, PortfolioCustomerViewModel>(result);
            return View(model);
        }

        // POST: PortfolioCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.PortfolioCustomers.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
