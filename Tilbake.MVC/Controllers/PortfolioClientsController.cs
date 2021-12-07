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
    public class PortfolioClientsController : BaseController
    {
        public PortfolioClientsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Search(Guid portfolioId, string searchString = "~#")
        {
            var portfolio = await _unitOfWork.Portfolios.GetById(portfolioId);
            var clients = await _unitOfWork.PortfolioClients.GetByPortfolioId(portfolioId);

            var clientModel = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(clients);

            if (!String.IsNullOrEmpty(searchString) && portfolioId != Guid.Empty)
            {
                clientModel = clientModel.Where(r => r.LastName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                        || r.FirstName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                        || r.IdNumber.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
            }

            PortfolioClientSearchViewModel model = new()
            {
                PortfolioId = portfolioId,
                PortfolioName = portfolio.Name,
                SearchString = "",
                Clients = clientModel
            };
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> CreateWizard(Guid portfolioId)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var result = await _unitOfWork.ApplicationSessions.GetByUserId(user.Id);

            PortfolioClientViewModel model = new()
            {
                PortfolioId = Guid.Parse(result.FirstOrDefault(n => n.Name == "PortfolioId").Value)
            };
            ClientViewModel clientModel = new()
            {
                PortfolioName = result.FirstOrDefault(n => n.Name == "PortfolioName").Value
            };
            model.Client = clientModel;

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
                TableName = "Client"
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
                //await _clientService.ImportBulkAsync(ViewModel);
                return RedirectToAction(nameof(LoadBulks), new { model.PortfolioId });
            }

            return View(model);
        }

        public async Task<IActionResult> LoadBulks(Guid portfolioId)
        {
            //var ViewModels = await _clientService.GetBulkByPortfolioIdAsync(portfolioId);
            var portfolio = await _unitOfWork.Portfolios.GetByIdAsync(portfolioId);

            ViewBag.PortfolioId = portfolioId;
            ViewBag.PortfolioName = portfolio.Name;

            return View();
        }

        [HttpPost, ActionName("LoadBulks")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoadConfirmed(List<ClientBulkViewModel> model)
        {
            var portfolioId = model.GroupBy(r => r.PortfolioId).FirstOrDefault().Key;
            var portfolio = await _unitOfWork.Portfolios.GetByIdAsync((Guid)portfolioId);

            if (ModelState.IsValid)
            {
                //await _clientService.AddBulkAsync((Guid)portfolioId);
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
        //public async Task<IActionResult> GetPortfolioClients(Guid portfolioId, string category, string searchString)
        //{
            //var result = await _clientService.GetByPortfolioIdAsync(portfolioId);

            //switch (category)
            //{
            //    case "Client Number":
            //        bool isNumber = int.TryParse(searchString, out int n);
            //        if (isNumber)
            //        {
            //            result = result.Where(r => r.ClientNumber == n);
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

        public async Task<IActionResult> Details(Guid portfolioId, Guid clientId)
        {
            var result = await _unitOfWork.PortfolioClients.GetByPortfolioIdAndClientId(portfolioId, clientId);
            var model = _mapper.Map<Client, ClientViewModel>(result);

            var cityId = model.Addresses.FirstOrDefault().CityId;
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

            model.PortfolioId = portfolioId;
            model.PortfolioName = model.PortfolioName;
            model.CountryList = MVCHelperExtensions.ToSelectList(countries, model.CountryId);
            model.ClientTypeList = MVCHelperExtensions.ToSelectList(clientTypes, model.ClientTypeId);
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

        // GET: PortfolioClients/Create
        public async Task<IActionResult> Create(Guid portfolioId)
        {
            var carriers = await _unitOfWork.Carriers.GetAll(r => r.OrderBy(n => n.Name));
            var clientTypes = await _unitOfWork.ClientTypes.GetAll(r => r.OrderBy(n => n.Name));
            var clientStatuses = await _unitOfWork.ClientStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var countries = await _unitOfWork.Countries.GetAll(r => r.OrderBy(n => n.Name));
            var genders = await _unitOfWork.Genders.GetAll(r => r.OrderBy(n => n.Name));
            var idDocumentTypes = await _unitOfWork.IdDocumentTypes.GetAll(r => r.OrderBy(n => n.Name));
            var maritalStatuses = await _unitOfWork.MaritalStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var occupations = await _unitOfWork.Occupations.GetAll(r => r.OrderBy(n => n.Name));
            var titles = await _unitOfWork.Titles.GetAll(r => r.OrderBy(n => n.Name));

            var portfolio = await _unitOfWork.Portfolios.GetById(portfolioId);

            PortfolioClientViewModel model = new()
            {
                PortfolioId = portfolioId,
                ClientStatusList = MVCHelperExtensions.ToSelectList(clientStatuses, Guid.Empty)
            };

            //AddressViewModel addressViewModel = new()
            //{
            //    CountryList = MVCHelperExtensions.ToSelectList(countries, Guid.Empty)
            //};

            ClientViewModel clientViewModel = new()
            {
                PortfolioName = portfolio.Name,
                BirthDate = DateTime.Now.Date,

                ClientTypeList = MVCHelperExtensions.ToSelectList(clientTypes, Guid.Empty),
                CountryList = MVCHelperExtensions.ToSelectList(countries, Guid.Empty),
                GenderList = MVCHelperExtensions.ToSelectList(genders, Guid.Empty),
                IdDocumentTypeList = MVCHelperExtensions.ToSelectList(idDocumentTypes, Guid.Empty),
                MaritalStatusList = MVCHelperExtensions.ToSelectList(maritalStatuses, Guid.Empty),
                OccupationList = MVCHelperExtensions.ToSelectList(occupations, Guid.Empty),
                TitleList = MVCHelperExtensions.ToSelectList(titles, Guid.Empty)
            };

            clientViewModel.CarrierList = MVCHelperExtensions.ToMultiSelectList(carriers, clientViewModel.CarrierIds);
            //clientViewModel.Addresses = addressViewModel;
            model.Client = clientViewModel;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var clientViewModel = model.Client;
                Guid clientId = Guid.NewGuid();

                var client = _mapper.Map<ClientViewModel, Client>(clientViewModel);

                if (client != null)
                {
                    client.Id = clientId;
                    client.DateAdded = DateTime.Now;

                    clientId = client.Id;

                    var portfolioClient = _mapper.Map<PortfolioClientViewModel, PortfolioClient>(model);

                    portfolioClient.Id = Guid.NewGuid();
                    portfolioClient.ClientId = clientId;
                    portfolioClient.DateAdded = DateTime.Now;

                    client.PortfolioClients.Add(portfolioClient);
                    await _unitOfWork.Clients.Add(client);

                    //var addressViewModel = model.Client.Address;

                    //if (addressViewModel != null)
                    //{
                    //    var address = _mapper.Map<AddressViewModel, Address>(addressViewModel);

                    //    address.Id = Guid.NewGuid();
                    //    address.ClientId = clientId;
                    //    address.DateAdded = DateTime.Now;
                    //    await _unitOfWork.Addresses.Add(address);
                    //}

                    var emailAddressesViewModels = model.Client.EmailAddresses;
                    if (emailAddressesViewModels.Count > 0)
                    {
                        var emailAddresses = _mapper.Map<IEnumerable<EmailAddressViewModel>, IEnumerable<EmailAddress>>(emailAddressesViewModels);

                        foreach (var emailAddress in emailAddresses)
                        {
                            emailAddress.Id = Guid.NewGuid();
                            emailAddress.ClientId = clientId;
                            emailAddress.DateAdded = DateTime.Now;
                            await _unitOfWork.EmailAddresses.Add(emailAddress);
                        }
                    }

                    var mobileNumbersViewModels = model.Client.MobileNumbers;
                    if (mobileNumbersViewModels.Count > 0)
                    {
                        var mobileNumbers = _mapper.Map<IEnumerable<MobileNumberViewModel>, IEnumerable<MobileNumber>>(mobileNumbersViewModels);
                        foreach (var mobileNumber in mobileNumbers)
                        {
                            mobileNumber.Id = Guid.NewGuid();
                            mobileNumber.ClientId = clientId;
                            mobileNumber.DateAdded = DateTime.Now;
                            await _unitOfWork.MobileNumbers.Add(mobileNumber);
                        }
                    }

                    var carrierIds = model.Client.CarrierIds;
                    if (carrierIds != null)
                    {
                        foreach (var carrierId in carrierIds)
                        {
                            ClientCarrier newClientCarrier = new()
                            {
                                ClientId = clientId,
                                CarrierId = carrierId,
                                DateAdded = DateTime.Now
                            };
                            await _unitOfWork.ClientCarriers.Add(newClientCarrier);
                        }
                    }
                    await _unitOfWork.CompleteAsync();

                }
                return RedirectToAction(nameof(Search), new { portfolioId = model.PortfolioId, searchString = model.Client.LastName });
            }

            var countryId = model.Client.CountryId;
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

            var portfolio = await _unitOfWork.Portfolios.GetById(model.PortfolioId);

            model.ClientStatusList = MVCHelperExtensions.ToSelectList(clientStatuses, model.ClientStatusId);
            model.Client.CountryList = MVCHelperExtensions.ToSelectList(countries, model.Client.CountryId);
            model.Client.ClientTypeList = MVCHelperExtensions.ToSelectList(clientTypes, model.Client.ClientTypeId);
            model.Client.CountryList = MVCHelperExtensions.ToSelectList(countries, model.Client.CountryId);
            model.Client.GenderList = MVCHelperExtensions.ToSelectList(genders, model.Client.GenderId);
            model.Client.IdDocumentTypeList = MVCHelperExtensions.ToSelectList(idDocumentTypes, model.Client.IdDocumentTypeId);
            model.Client.MaritalStatusList = MVCHelperExtensions.ToSelectList(maritalStatuses, model.Client.MaritalStatusId);
            model.Client.OccupationList = MVCHelperExtensions.ToSelectList(occupations, model.Client.OccupationId);
            model.Client.TitleList = MVCHelperExtensions.ToSelectList(titles, model.Client.TitleId);
            model.Client.CarrierList = MVCHelperExtensions.ToMultiSelectList(carriers, model.Client.CarrierIds);

            //model.Client.AddressCountryList = MVCHelperExtensions.ToSelectList(countries, countryId);
            //model.Client.CityList = MVCHelperExtensions.ToSelectList(cities, model.Client.Address.CityId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddExistingClient(Guid portfolioId, Guid clientId)
        {
            PortfolioClient newPortfolioClient = new()
            {
                Id = Guid.NewGuid(),
                PortfolioId = portfolioId,
                ClientId = clientId,
                ClientStatusId = Guid.Parse(Constants.DefaultClientStatusId),
                DateAdded = DateTime.Now
            };
;
            await _unitOfWork.PortfolioClients.Add(newPortfolioClient);
            await _unitOfWork.CompleteAsync();
            return Json(new { portfolioId, clientId });
        }

        [HttpGet]
        public async Task<IActionResult> GetByPortfolioIdAndIdNumber(Guid portfolioId, string idNumber)
        {
            var result = await _unitOfWork.PortfolioClients.GetByPortfolioIdAndIdNumber(portfolioId, idNumber);
            var model = _mapper.Map<Client, ClientViewModel>(result);
            return Json(model);
        }

        [HttpGet] 
        public async Task<IActionResult> Edit(Guid portfolioId, Guid clientId)
        {
            var result = await _unitOfWork.PortfolioClients.GetByPortfolioIdAndClientId(portfolioId, clientId);
            var model = _mapper.Map<Client, ClientViewModel>(result);

            //var cityId = model.Address.CityId;
            //var city = await _unitOfWork.Cities.GetById(cityId);
            //var countryId = city.CountryId;

            var carriers = await _unitOfWork.Carriers.GetAll(r => r.OrderBy(n => n.Name));
            //var cities = await _unitOfWork.Cities.GetByCountryId(countryId);
            var clientTypes = await _unitOfWork.ClientTypes.GetAll(r => r.OrderBy(n => n.Name));
            var clientStatuses = await _unitOfWork.ClientStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var countries = await _unitOfWork.Countries.GetAll(r => r.OrderBy(n => n.Name));
            var genders = await _unitOfWork.Genders.GetAll(r => r.OrderBy(n => n.Name));
            var idDocumentTypes = await _unitOfWork.IdDocumentTypes.GetAll(r => r.OrderBy(n => n.Name));
            var maritalStatuses = await _unitOfWork.MaritalStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var occupations = await _unitOfWork.Occupations.GetAll(r => r.OrderBy(n => n.Name));
            var titles = await _unitOfWork.Titles.GetAll(r => r.OrderBy(n => n.Name));

            model.PortfolioId = portfolioId;
            model.CountryList = MVCHelperExtensions.ToSelectList(countries, model.CountryId);
            model.ClientTypeList = MVCHelperExtensions.ToSelectList(clientTypes, model.ClientTypeId);
            model.CountryList = MVCHelperExtensions.ToSelectList(countries, model.CountryId);
            model.GenderList = MVCHelperExtensions.ToSelectList(genders, model.GenderId);
            model.IdDocumentTypeList = MVCHelperExtensions.ToSelectList(idDocumentTypes, model.IdDocumentTypeId);
            model.MaritalStatusList = MVCHelperExtensions.ToSelectList(maritalStatuses, model.MaritalStatusId);
            model.OccupationList = MVCHelperExtensions.ToSelectList(occupations, model.OccupationId);
            model.TitleList = MVCHelperExtensions.ToSelectList(titles, model.TitleId);

            model.CarrierList = MVCHelperExtensions.ToMultiSelectList(carriers, model.CarrierIds);

            //model.AddressCountryList = MVCHelperExtensions.ToSelectList(countries, countryId);
            //model.CityList = MVCHelperExtensions.ToSelectList(cities, cityId);

            return View("EditClient", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClientViewModel model)
        {
            if(ModelState.IsValid)
            {
                var client = _mapper.Map<ClientViewModel, Client>(model);
                
                client.DateModified = DateTime.Now;
                await _unitOfWork.Clients.Update(client);

                var clientId = client.Id;
                //var addressViewModel = model.Address;
                //var address = _mapper.Map<AddressViewModel, Address>(addressViewModel);

                //address.ClientId = clientId;
                //address.DateAdded = DateTime.Now;
                //await _unitOfWork.Addresses.Update(address);

                var emailAddressesViewModels = model.EmailAddresses;
                var emailAddresses = _mapper.Map<IEnumerable<EmailAddressViewModel>, IEnumerable<EmailAddress>>(emailAddressesViewModels);

                foreach (var emailAddress in emailAddresses)
                {
                    emailAddress.ClientId = clientId;
                    emailAddress.DateModified = DateTime.Now;
                    await _unitOfWork.EmailAddresses.Update(emailAddress);
                }

                var mobileNumbersViewModels = model.MobileNumbers;
                var mobileNumbers = _mapper.Map<IEnumerable<MobileNumberViewModel>, IEnumerable<MobileNumber>>(mobileNumbersViewModels);
                foreach (var mobileNumber in mobileNumbers)
                {
                    mobileNumber.ClientId = clientId;
                    mobileNumber.DateModified = DateTime.Now;
                    await _unitOfWork.MobileNumbers.Update(mobileNumber);
                }
                
                var carrierIds = model.CarrierIds;
                var clientCarriers = await _unitOfWork.ClientCarriers.GetByClientId(clientId);

                _unitOfWork.ClientCarriers.DeleteRange(clientCarriers);

                if (carrierIds != null)
                {
                    List<ClientCarrier> newClientCarriers = new();

                    foreach (var carrierId in carrierIds)
                    {
                        ClientCarrier newClientCarrier = new()
                        {
                            ClientId = clientId,
                            CarrierId = carrierId,
                            DateAdded = DateTime.Now
                        };
                        newClientCarriers.Add(newClientCarrier);
                    }
                    _unitOfWork.ClientCarriers.AddRange(newClientCarriers);
                }
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Edit), new { portfolioId = model.PortfolioId, clientId = model.Id });
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

            //model.Address.CountryList = MVCHelperExtensions.ToSelectList(countries, model.Address.CountryId);
            //model.Address.CityList = MVCHelperExtensions.ToSelectList(cities, model.Address.CityId);

            return View("EditClient", model);
        }

        // GET: PortfolioClients/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.PortfolioClients.GetById(id);
            var model = _mapper.Map<PortfolioClient, PortfolioClientViewModel>(result);
            return View(model);
        }

        // POST: PortfolioClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.PortfolioClients.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
