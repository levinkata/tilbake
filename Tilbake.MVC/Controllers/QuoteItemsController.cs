using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Core;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Helpers;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class QuoteItemsController : BaseController
    {
        public QuoteItemsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> QuoteItemRisk(Guid id)
        {
            var resultAllRisk = await _unitOfWork.QuoteItems.GetAllRisk(id);
            var resultAllRiskSpecified = await _unitOfWork.QuoteItems.GetAllRiskSpecified(id);
            var resultBuilding = await _unitOfWork.QuoteItems.GetBuilding(id);
            var resultContent = await _unitOfWork.QuoteItems.GetContent(id);
            var resultExcessBuyBack = await _unitOfWork.QuoteItems.GetExcessBuyBack(id);
            var resultHouse = await _unitOfWork.QuoteItems.GetHouse(id);
            var resultMotor = await _unitOfWork.QuoteItems.GetMotor(id);
            var resultTravel = await _unitOfWork.QuoteItems.GetTravel(id);

            var modelAllRisk = _mapper.Map<AllRisk, AllRiskViewModel>(resultAllRisk);
            var modelAllRiskSpecified = _mapper.Map<AllRiskSpecified, AllRiskSpecifiedViewModel>(resultAllRiskSpecified);
            var modelBuilding = _mapper.Map<Building, BuildingViewModel>(resultBuilding);
            var modelContent = _mapper.Map<Content, ContentViewModel>(resultContent);
            var modelExcessBuyBack = _mapper.Map<ExcessBuyBack, ExcessBuyBackViewModel>(resultExcessBuyBack);
            var modelHouse = _mapper.Map<House, HouseViewModel>(resultHouse);
            var modelMotor = _mapper.Map<Motor, MotorViewModel>(resultMotor);
            var modelTravel = _mapper.Map<Travel, TravelViewModel>(resultTravel);

            QuoteItemObjectViewModel quoteItemObjectModel = new()
            {
                AllRisk = modelAllRisk,
                AllRiskSpecified = modelAllRiskSpecified,
                Building = modelBuilding,
                Content = modelContent,
                ExcessBuyBack = modelExcessBuyBack,
                House = modelHouse,
                Motor = modelMotor,
                Travel = modelTravel
            };

            var quote = await _unitOfWork.QuoteItems.GetById(id);

            if (quoteItemObjectModel == null)
            {
                return NotFound();
            }

            var returnView = "";
            object model = null;

            //  AllRisk
            if (quoteItemObjectModel.AllRisk != null)
            {
                returnView = "QuoteAllRisk";
                AllRiskViewModel allRiskViewModel = quoteItemObjectModel.AllRisk;
                var riskItem = allRiskViewModel.RiskItemId;
                var result = await _unitOfWork.RiskItems.GetById(riskItem);

                allRiskViewModel.QuoteItemId = id;
                allRiskViewModel.QuoteId = quote.QuoteId;
                allRiskViewModel.RiskItem = result.Description;
                model = allRiskViewModel;
            }

            //  AllRiskSpecified
            if (quoteItemObjectModel.AllRisk != null)
            {
                returnView = "QuoteAllRiskSpecified";
                AllRiskSpecifiedViewModel allRiskSpecifiedViewModel = quoteItemObjectModel.AllRiskSpecified;
                var riskItem = allRiskSpecifiedViewModel.RiskItemId;
                var result = await _unitOfWork.RiskItems.GetById(riskItem);

                allRiskSpecifiedViewModel.QuoteItemId = id;
                allRiskSpecifiedViewModel.QuoteId = quote.QuoteId;
                allRiskSpecifiedViewModel.RiskItem = result.Description;
                model = allRiskSpecifiedViewModel;
            }

            //  Building
            if (quoteItemObjectModel.Building != null)
            {
                var residenceTypes = await _unitOfWork.ResidenceTypes.GetAll(r => r.OrderBy(n => n.Name));
                var residenceUses = await _unitOfWork.ResidenceUses.GetAll(r => r.OrderBy(n => n.Name));
                var buildingConditions = await _unitOfWork.BuildingConditions.GetAll(r => r.OrderBy(n => n.Name));
                var roofTypes = await _unitOfWork.RoofTypes.GetAll(r => r.OrderBy(n => n.Name));
                var wallTypes = await _unitOfWork.WallTypes.GetAll(r => r.OrderBy(n => n.Name));

                returnView = "QuoteBuilding";
                BuildingViewModel buildingViewModel = quoteItemObjectModel.Building;
                buildingViewModel.QuoteItemId = id;
                buildingViewModel.QuoteId = quote.QuoteId;
                buildingViewModel.ResidenceTypeList = MVCHelperExtensions.ToSelectList(residenceTypes, buildingViewModel.ResidenceTypeId);
                buildingViewModel.ResidenceUseList = MVCHelperExtensions.ToSelectList(residenceUses, buildingViewModel.ResidenceUseId);
                buildingViewModel.BuildingConditionList = MVCHelperExtensions.ToSelectList(buildingConditions, buildingViewModel.BuildingConditionId);
                buildingViewModel.RoofTypeList = MVCHelperExtensions.ToSelectList(roofTypes, buildingViewModel.RoofTypeId);
                buildingViewModel.WallTypeList = MVCHelperExtensions.ToSelectList(wallTypes, buildingViewModel.WallTypeId);
                model = buildingViewModel;
            }

            //  Content
            if (quoteItemObjectModel.Content != null)
            {
                var residenceTypes = await _unitOfWork.ResidenceTypes.GetAll(r => r.OrderBy(n => n.Name));
                var residenceUses = await _unitOfWork.ResidenceUses.GetAll(r => r.OrderBy(n => n.Name));
                var roofTypes = await _unitOfWork.RoofTypes.GetAll(r => r.OrderBy(n => n.Name));
                var wallTypes = await _unitOfWork.WallTypes.GetAll(r => r.OrderBy(n => n.Name));

                returnView = "QuoteContent";
                ContentViewModel contentViewModel = quoteItemObjectModel.Content;
                contentViewModel.QuoteItemId = id;
                contentViewModel.QuoteId = quote.QuoteId;
                contentViewModel.ResidenceTypeList = MVCHelperExtensions.ToSelectList(residenceTypes, contentViewModel.ResidenceTypeId);
                contentViewModel.ResidenceUseList = MVCHelperExtensions.ToSelectList(residenceUses, contentViewModel.ResidenceUseId);
                contentViewModel.RoofTypeList = MVCHelperExtensions.ToSelectList(roofTypes, contentViewModel.RoofTypeId);
                contentViewModel.WallTypeList = MVCHelperExtensions.ToSelectList(wallTypes, contentViewModel.WallTypeId);
                model = contentViewModel;
            }

            //  ExcessBuyBack
            if (quoteItemObjectModel.ExcessBuyBack != null)
            {
                returnView = "QuoteExcessBuyBack";
                ExcessBuyBackViewModel excessBuyBackViewModel = quoteItemObjectModel.ExcessBuyBack;
                excessBuyBackViewModel.QuoteItemId = id;
                excessBuyBackViewModel.QuoteId = quote.QuoteId;
                model = excessBuyBackViewModel;
            }

            //  House
            if (quoteItemObjectModel.House != null)
            {
                var residenceTypes = await _unitOfWork.ResidenceTypes.GetAll(r => r.OrderBy(n => n.Name));
                var houseConditions = await _unitOfWork.HouseConditions.GetAll(r => r.OrderBy(n => n.Name));
                var roofTypes = await _unitOfWork.RoofTypes.GetAll(r => r.OrderBy(n => n.Name));
                var wallTypes = await _unitOfWork.WallTypes.GetAll(r => r.OrderBy(n => n.Name));

                returnView = "QuoteHouse";
                HouseViewModel houseViewModel = quoteItemObjectModel.House;
                houseViewModel.QuoteItemId = id;
                houseViewModel.QuoteId = quote.QuoteId;
                houseViewModel.ResidenceTypeList = MVCHelperExtensions.ToSelectList(residenceTypes, houseViewModel.ResidenceTypeId);
                houseViewModel.HouseConditionList = MVCHelperExtensions.ToSelectList(houseConditions, houseViewModel.HouseConditionId);
                houseViewModel.RoofTypeList = MVCHelperExtensions.ToSelectList(roofTypes, houseViewModel.RoofTypeId);
                houseViewModel.WallTypeList = MVCHelperExtensions.ToSelectList(wallTypes, houseViewModel.WallTypeId);
                model = houseViewModel;
            }

            //  Motor
            if (quoteItemObjectModel.Motor != null)
            {
                var bodyTypes = await _unitOfWork.BodyTypes.GetAll(r => r.OrderBy(n => n.Name));
                var driverTypes = await _unitOfWork.DriverTypes.GetAll(r => r.OrderBy(n => n.Name));
                var motorMakes = await _unitOfWork.MotorMakes.GetAll(r => r.OrderBy(n => n.Name));

                returnView = "QuoteMotor";
                MotorViewModel motorViewModel = quoteItemObjectModel.Motor;

                var selectedMotorModel = await _unitOfWork.MotorModels.GetById(motorViewModel.MotorModelId);
                var selectedMotorMakeId = selectedMotorModel.MotorMakeId;
                var motorModels = await _unitOfWork.MotorModels.GetByMotorMakeId(selectedMotorMakeId);

                motorViewModel.QuoteItemId = id;
                motorViewModel.QuoteId = quote.QuoteId;
                motorViewModel.MotorMakeId = selectedMotorMakeId;
                motorViewModel.BodyTypeList = MVCHelperExtensions.ToSelectList(bodyTypes, motorViewModel.BodyTypeId);
                motorViewModel.DriverTypeList = MVCHelperExtensions.ToSelectList(driverTypes, motorViewModel.DriverTypeId);
                motorViewModel.MotorMakeList = MVCHelperExtensions.ToSelectList(motorMakes, selectedMotorMakeId);
                motorViewModel.MotorModelList = MVCHelperExtensions.ToSelectList(motorModels, motorViewModel.MotorModelId);

                model = motorViewModel;
            }

            //  Travel
            if (quoteItemObjectModel.Travel != null)
            {
                returnView = "QuoteTravel";
                TravelViewModel travelViewModel = quoteItemObjectModel.Travel;

                travelViewModel.QuoteItemId = id;
                travelViewModel.QuoteId = quote.QuoteId;
                model = travelViewModel;
            }
            return View(returnView, model);
        }


        // POST: QuoteItems/EditAllRisk/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllRisk(Guid? id, AllRiskViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var quoteItem = await _unitOfWork.QuoteItems.GetById(model.QuoteItemId);
                quoteItem.Description = "AllRisks - " + model.RiskItem;

                RiskItem riskItem = new()
                {
                    Id = model.RiskItemId,
                    Description = model.RiskItem
                };

                var taxes = await _unitOfWork.Taxes.GetAll(r => r.OrderByDescending(n => n.TaxDate));
                var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

                quoteItem.DateModified = DateTime.Now;
                quoteItem.TaxRate = taxRate;
                quoteItem.TaxAmount = quoteItem.Premium - (quoteItem.Premium / (1 + taxRate / 100));

                _unitOfWork.QuoteItems.Update(model.QuoteItemId, quoteItem);
                _unitOfWork.RiskItems.Update(model.RiskItemId, riskItem);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Details), "Quotes", new { id = quoteItem.QuoteId });
            }

            return View(model);
        }

        // POST: QuoteItems/EditAllRiskSpecified/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllRiskSpecified(Guid? id, AllRiskSpecifiedViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var quoteItem = await _unitOfWork.QuoteItems.GetById(model.QuoteItemId);
                quoteItem.Description = "AllRiskSpecifieds - " + model.RiskItem;

                RiskItem riskItem = new()
                {
                    Id = model.RiskItemId,
                    Description = model.RiskItem
                };

                var taxes = await _unitOfWork.Taxes.GetAll(r => r.OrderByDescending(n => n.TaxDate));
                var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

                quoteItem.DateModified = DateTime.Now;
                quoteItem.TaxRate = taxRate;
                quoteItem.TaxAmount = quoteItem.Premium - (quoteItem.Premium / (1 + taxRate / 100));

                _unitOfWork.QuoteItems.Update(model.QuoteItemId, quoteItem);
                _unitOfWork.RiskItems.Update(model.RiskItemId, riskItem);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Details), "Quotes", new { id = quoteItem.QuoteId });
            }

            return View(model);
        }

        // POST: QuoteItems/EditBuilding/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBuilding(Guid? id, BuildingViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var quoteItem = await _unitOfWork.QuoteItems.GetById(model.QuoteItemId);
                quoteItem.Description = "Building - " + model.PhysicalAddress;

                var taxes = await _unitOfWork.Taxes.GetAll(r => r.OrderByDescending(n => n.TaxDate));
                var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

                quoteItem.DateModified = DateTime.Now;
                quoteItem.TaxRate = taxRate;
                quoteItem.TaxAmount = quoteItem.Premium - (quoteItem.Premium / (1 + taxRate / 100));

                var building = _mapper.Map<BuildingViewModel, Building>(model);

                _unitOfWork.QuoteItems.Update(model.QuoteItemId, quoteItem);
                _unitOfWork.Buildings.Update(model.Id, building);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Details), "Quotes", new { id = model.QuoteId });
            }

            var residenceTypes = await _unitOfWork.ResidenceTypes.GetAll(r => r.OrderBy(n => n.Name));
            var residenceUses = await _unitOfWork.ResidenceUses.GetAll(r => r.OrderBy(n => n.Name));
            var buildingConditions = await _unitOfWork.BuildingConditions.GetAll(r => r.OrderBy(n => n.Name));
            var roofTypes = await _unitOfWork.RoofTypes.GetAll(r => r.OrderBy(n => n.Name));
            var wallTypes = await _unitOfWork.WallTypes.GetAll(r => r.OrderBy(n => n.Name));

            model.ResidenceTypeList = MVCHelperExtensions.ToSelectList(residenceTypes, model.ResidenceTypeId);
            model.ResidenceUseList = MVCHelperExtensions.ToSelectList(residenceUses, model.ResidenceUseId);
            model.BuildingConditionList = MVCHelperExtensions.ToSelectList(buildingConditions, model.BuildingConditionId);
            model.RoofTypeList = MVCHelperExtensions.ToSelectList(roofTypes, model.RoofTypeId);
            model.WallTypeList = MVCHelperExtensions.ToSelectList(wallTypes, model.WallTypeId);
            return View(model);
        }

        // POST: QuoteItems/EditContent/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditContent(Guid? id, ContentViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var quoteItem = await _unitOfWork.QuoteItems.GetById(model.QuoteItemId);
                quoteItem.Description = "Contents - " + model.PhysicalAddress;

                var taxes = await _unitOfWork.Taxes.GetAll(r => r.OrderByDescending(n => n.TaxDate));
                var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

                quoteItem.DateModified = DateTime.Now;
                quoteItem.TaxRate = taxRate;
                quoteItem.TaxAmount = quoteItem.Premium - (quoteItem.Premium / (1 + taxRate / 100));

                var content = _mapper.Map<ContentViewModel, Content>(model);

                _unitOfWork.QuoteItems.Update(model.QuoteItemId, quoteItem);
                _unitOfWork.Contents.Update(model.Id, content);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(QuoteItemRisk), new { quoteItemId = model.QuoteItemId });
            }

            var residenceTypes = await _unitOfWork.ResidenceTypes.GetAll(r => r.OrderBy(n => n.Name));
            var residenceUses = await _unitOfWork.ResidenceUses.GetAll(r => r.OrderBy(n => n.Name));
            var roofTypes = await _unitOfWork.RoofTypes.GetAll(r => r.OrderBy(n => n.Name));
            var wallTypes = await _unitOfWork.WallTypes.GetAll(r => r.OrderBy(n => n.Name));

            model.ResidenceTypeList = MVCHelperExtensions.ToSelectList(residenceTypes, model.ResidenceTypeId);
            model.ResidenceUseList = MVCHelperExtensions.ToSelectList(residenceUses, model.ResidenceUseId);
            model.RoofTypeList = MVCHelperExtensions.ToSelectList(roofTypes, model.RoofTypeId);
            model.WallTypeList = MVCHelperExtensions.ToSelectList(wallTypes, model.WallTypeId);
            return View(model);
        }

        // POST: QuoteItems/EditHouse/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHouse(Guid? id, HouseViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var quoteItem = await _unitOfWork.QuoteItems.GetById(model.QuoteItemId);
                quoteItem.Description = "House - " + model.PhysicalAddress;

                var taxes = await _unitOfWork.Taxes.GetAll(r => r.OrderByDescending(n => n.TaxDate));
                var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

                quoteItem.DateModified = DateTime.Now;
                quoteItem.TaxRate = taxRate;
                quoteItem.TaxAmount = quoteItem.Premium - (quoteItem.Premium / (1 + taxRate / 100));

                var house = _mapper.Map<HouseViewModel, House>(model);
                _unitOfWork.QuoteItems.Update(model.QuoteItemId, quoteItem);
                _unitOfWork.Houses.Update(model.Id, house);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(QuoteItemRisk), new { quoteItemId = model.QuoteItemId });
            }

            var residenceTypes = await _unitOfWork.ResidenceTypes.GetAll(r => r.OrderBy(n => n.Name));
            var houseConditions = await _unitOfWork.HouseConditions.GetAll(r => r.OrderBy(n => n.Name));
            var roofTypes = await _unitOfWork.RoofTypes.GetAll(r => r.OrderBy(n => n.Name));
            var wallTypes = await _unitOfWork.WallTypes.GetAll(r => r.OrderBy(n => n.Name));

            model.ResidenceTypeList = MVCHelperExtensions.ToSelectList(residenceTypes, model.ResidenceTypeId);
            model.HouseConditionList = MVCHelperExtensions.ToSelectList(houseConditions, model.HouseConditionId);
            model.RoofTypeList = MVCHelperExtensions.ToSelectList(roofTypes, model.RoofTypeId);
            model.WallTypeList = MVCHelperExtensions.ToSelectList(wallTypes, model.WallTypeId);
            return View(model);
        }

        // POST: QuoteItems/EditMotor/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMotor(MotorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var quoteItem = await _unitOfWork.QuoteItems.GetById(model.QuoteItemId);
                var motorMake = await _unitOfWork.MotorMakes.GetById(model.MotorMakeId);
                quoteItem.Description = "Motor - " + model.RegYear + " " + motorMake.Name + " " + model.RegNumber;

                var taxes = await _unitOfWork.Taxes.GetAll(r => r.OrderByDescending(n => n.TaxDate));
                var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

                quoteItem.DateModified = DateTime.Now;
                quoteItem.TaxRate = taxRate;
                quoteItem.TaxAmount = quoteItem.Premium - (quoteItem.Premium / (1 + taxRate / 100));

                var motor = _mapper.Map<MotorViewModel, Motor>(model);
                _unitOfWork.QuoteItems.Update(model.QuoteItemId, quoteItem);
                _unitOfWork.Motors.Update(model.Id, motor);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Details), "Quotes", new { id = model.QuoteId });
            }

            var bodyTypes = await _unitOfWork.BodyTypes.GetAll(r => r.OrderBy(n => n.Name));
            var driverTypes = await _unitOfWork.DriverTypes.GetAll(r => r.OrderBy(n => n.Name));
            var motorMakes = await _unitOfWork.MotorMakes.GetAll(r => r.OrderBy(n => n.Name));
            var motorModels = await _unitOfWork.MotorModels.GetByMotorMakeId(model.MotorMakeId);

            model.BodyTypeList = MVCHelperExtensions.ToSelectList(bodyTypes, model.BodyTypeId);
            model.DriverTypeList = MVCHelperExtensions.ToSelectList(driverTypes, model.DriverTypeId);
            model.MotorMakeList = MVCHelperExtensions.ToSelectList(motorMakes, model.MotorMakeId);
            model.MotorModelList = MVCHelperExtensions.ToSelectList(motorModels, model.MotorModelId);

            return View(model);
        }

        // POST: QuoteItems/EditTravel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTravel(TravelViewModel model)
        {
            if (ModelState.IsValid)
            {
                var quoteItem = await _unitOfWork.QuoteItems.GetById(model.QuoteItemId);
                quoteItem.Description = "Travel - " + model.Client.FirstName + " " + model.Client.LastName;

                var taxes = await _unitOfWork.Taxes.GetAll(r => r.OrderByDescending(n => n.TaxDate));
                var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

                quoteItem.DateModified = DateTime.Now;
                quoteItem.TaxRate = taxRate;
                quoteItem.TaxAmount = quoteItem.Premium - (quoteItem.Premium / (1 + taxRate / 100));

                var travel = _mapper.Map<TravelViewModel, Travel>(model);
                _unitOfWork.QuoteItems.Update(model.QuoteItemId, quoteItem);
                _unitOfWork.Travels.Update(model.Id, travel);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Details), "Quotes", new { id = model.QuoteId });
            }

            return View(model);
        }

        // GET: QuoteItems/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var quoteItem = await _unitOfWork.QuoteItems.GetById(id);
            if (quoteItem == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<QuoteItem, QuoteItemViewModel>(quoteItem);
            var coverTypes = await _unitOfWork.CoverTypes.GetAll(r => r.OrderBy(n => n.Name));
            model.CoverTypeList = MVCHelperExtensions.ToSelectList(coverTypes, model.CoverTypeId);
            return View(model);
        }

        // POST: QuoteItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, QuoteItemViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var quoteItem = _mapper.Map<QuoteItemViewModel, QuoteItem>(model);
                quoteItem.DateModified = DateTime.Now;

                var taxes = await _unitOfWork.Taxes.GetAll(r => r.OrderByDescending(n => n.TaxDate));
                var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

                quoteItem.DateModified = DateTime.Now;
                quoteItem.TaxRate = taxRate;
                quoteItem.TaxAmount = quoteItem.Premium - (quoteItem.Premium / (1 + taxRate / 100));

                _unitOfWork.QuoteItems.Update(model.Id, quoteItem);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Details), "Quotes", new { Id = model.QuoteId });
            }

            var coverTypes = await _unitOfWork.CoverTypes.GetAll(r => r.OrderBy(n => n.Name));
            model.CoverTypeList = MVCHelperExtensions.ToSelectList(coverTypes, model.CoverTypeId);
            return View(model);
        }

        // GET: QuoteItems/Detail/5
        public async Task<IActionResult> Details(Guid id)
        {
            var quoteItem = await _unitOfWork.QuoteItems.GetById(id);
            if (quoteItem == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<QuoteItem, QuoteItemViewModel>(quoteItem);
            return View(model);
        }

        // GET: QuoteItems/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var quoteItem = await _unitOfWork.QuoteItems.GetById(id);
            var model = _mapper.Map<QuoteItem, QuoteItemViewModel>(quoteItem);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: QuoteItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(QuoteItemViewModel model)
        {
            _unitOfWork.QuoteItems.Delete(model.Id);
            return RedirectToAction(nameof(Edit), "Quotes", new { model.QuoteId });
        }
    }
}
