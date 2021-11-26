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
using Tilbake.MVC.Helpers;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class PolicyRisksController : BaseController
    {
        public PolicyRisksController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> PolicyRisk(Guid id)
        {
            var resultAllRisk = await _unitOfWork.PolicyRisks.GetAllRisk(id);
            var resultAllRiskSpecified = await _unitOfWork.PolicyRisks.GetAllRiskSpecified(id);
            var resultBuilding = await _unitOfWork.PolicyRisks.GetBuilding(id);
            var resultContent = await _unitOfWork.PolicyRisks.GetContent(id);
            var resultHouse = await _unitOfWork.PolicyRisks.GetHouse(id);
            var resultMotor = await _unitOfWork.PolicyRisks.GetMotor(id);
            var resultTravel = await _unitOfWork.PolicyRisks.GetTravel(id);

            var modelAllRisk = _mapper.Map<AllRisk, AllRiskViewModel>(resultAllRisk);
            var modelAllRiskSpecified = _mapper.Map<AllRiskSpecified, AllRiskSpecifiedViewModel>(resultAllRiskSpecified);
            var modelBuilding = _mapper.Map<Building, BuildingViewModel>(resultBuilding);
            var modelContent = _mapper.Map<Content, ContentViewModel>(resultContent);
            var modelHouse = _mapper.Map<House, HouseViewModel>(resultHouse);
            var modelMotor = _mapper.Map<Motor, MotorViewModel>(resultMotor);
            var modelTravel = _mapper.Map<Travel, TravelViewModel>(resultTravel);

            PolicyRiskObjectViewModel policyRiskObjectModel = new()
            {
                AllRisk = modelAllRisk,
                AllRiskSpecified = modelAllRiskSpecified,
                Building = modelBuilding,
                Content = modelContent,
                House = modelHouse,
                Motor = modelMotor,
                Travel = modelTravel
            };

            var returnView = "";
            object model = null;

            if (policyRiskObjectModel.AllRisk != null)
            {
                returnView = "PolicyRiskAllRisk";
                AllRiskViewModel allRiskViewModel = policyRiskObjectModel.AllRisk;
                var riskItem = allRiskViewModel.RiskItemId;
                var result = await _unitOfWork.RiskItems.GetById(riskItem);

                allRiskViewModel.PolicyRiskId = id;
                allRiskViewModel.RiskItem = result.Description;
                model = allRiskViewModel;
            }

            if (policyRiskObjectModel.AllRiskSpecified != null)
            {
                returnView = "PolicyRiskAllRisk";
                AllRiskSpecifiedViewModel allRiskSpecifiedViewModel = policyRiskObjectModel.AllRiskSpecified;
                var riskItem = allRiskSpecifiedViewModel.RiskItemId;
                var result = await _unitOfWork.RiskItems.GetById(riskItem);

                allRiskSpecifiedViewModel.PolicyRiskId = id;
                allRiskSpecifiedViewModel.RiskItem = result.Description;
                model = allRiskSpecifiedViewModel;
            }

            if (policyRiskObjectModel.Content != null)
            {
                var residenceTypes = await _unitOfWork.ResidenceTypes.GetAll(r => r.OrderBy(n => n.Name));
                var residenceUses = await _unitOfWork.ResidenceUses.GetAll(r => r.OrderBy(n => n.Name));
                var roofTypes = await _unitOfWork.RoofTypes.GetAll(r => r.OrderBy(n => n.Name));
                var wallTypes = await _unitOfWork.WallTypes.GetAll(r => r.OrderBy(n => n.Name));

                returnView = "PolicyRiskContent";
                ContentViewModel contentViewModel = policyRiskObjectModel.Content;
                contentViewModel.PolicyRiskId = id;
                contentViewModel.ResidenceTypeList = MVCHelperExtensions.ToSelectList(residenceTypes, contentViewModel.ResidenceTypeId);
                contentViewModel.ResidenceUseList = MVCHelperExtensions.ToSelectList(residenceUses, contentViewModel.ResidenceUseId);
                contentViewModel.RoofTypeList = MVCHelperExtensions.ToSelectList(roofTypes, contentViewModel.RoofTypeId);
                contentViewModel.WallTypeList = MVCHelperExtensions.ToSelectList(wallTypes, contentViewModel.WallTypeId);
                model = contentViewModel;
            }

            if (policyRiskObjectModel.House != null)
            {
                var residenceTypes = await _unitOfWork.ResidenceTypes.GetAll(r => r.OrderBy(n => n.Name));
                var houseConditions = await _unitOfWork.HouseConditions.GetAll(r => r.OrderBy(n => n.Name));
                var roofTypes = await _unitOfWork.RoofTypes.GetAll(r => r.OrderBy(n => n.Name));
                var wallTypes = await _unitOfWork.WallTypes.GetAll(r => r.OrderBy(n => n.Name));

                returnView = "PolicyRiskHouse";
                HouseViewModel houseViewModel = policyRiskObjectModel.House;
                houseViewModel.PolicyRiskId = id;
                houseViewModel.ResidenceTypeList = MVCHelperExtensions.ToSelectList(residenceTypes, houseViewModel.ResidenceTypeId);
                houseViewModel.HouseConditionList = MVCHelperExtensions.ToSelectList(houseConditions, houseViewModel.HouseConditionId);
                houseViewModel.RoofTypeList = MVCHelperExtensions.ToSelectList(roofTypes, houseViewModel.RoofTypeId);
                houseViewModel.WallTypeList = MVCHelperExtensions.ToSelectList(wallTypes, houseViewModel.WallTypeId);
                model = houseViewModel;
            }

            if (policyRiskObjectModel.Motor != null)
            {
                var bodyTypes = await _unitOfWork.BodyTypes.GetAll(r => r.OrderBy(n => n.Name));
                var driverTypes = await _unitOfWork.DriverTypes.GetAll(r => r.OrderBy(n => n.Name));
                var motorMakes = await _unitOfWork.MotorMakes.GetAll(r => r.OrderBy(n => n.Name));

                returnView = "PolicyRiskMotor";
                MotorViewModel motorViewModel = policyRiskObjectModel.Motor;

                var selectedMotorModel = await _unitOfWork.MotorModels.GetById(motorViewModel.MotorModelId);
                var selectedMotorMakeId = selectedMotorModel.MotorMakeId;
                var motorModels = await _unitOfWork.MotorModels.GetByMotorMakeId(selectedMotorMakeId);

                motorViewModel.PolicyRiskId = id;
                motorViewModel.BodyTypeList = MVCHelperExtensions.ToSelectList(bodyTypes, motorViewModel.BodyTypeId);
                motorViewModel.DriverTypeList = MVCHelperExtensions.ToSelectList(driverTypes, motorViewModel.DriverTypeId);
                motorViewModel.MotorMakeList = MVCHelperExtensions.ToSelectList(motorMakes, selectedMotorMakeId);
                motorViewModel.MotorModelList = MVCHelperExtensions.ToSelectList(motorModels, motorViewModel.MotorModelId);
                model = motorViewModel;
            }

            if (policyRiskObjectModel.Travel != null)
            {
                returnView = "PolicyRiskTravel";
                TravelViewModel travelViewModel = policyRiskObjectModel.Travel;
                travelViewModel.PolicyRiskId = id;
                model = travelViewModel;
            }

            return View(returnView, model);
        }

        // POST: PolicyRisks/EditAllRisk/5
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
                var policyRisk = await _unitOfWork.PolicyRisks.GetByIdAsync(model.Id);
                policyRisk.Description = model.RiskItem;

                RiskItem riskItem = new()
                {
                    Id = model.RiskItemId,
                    Description = model.RiskItem
                };

                _unitOfWork.PolicyRisks.Update(model.PolicyRiskId, policyRisk);
                _unitOfWork.RiskItems.Update(model.RiskItemId, riskItem);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(PolicyRisk), new { policyRiskId = model.PolicyRiskId });
            }

            return View(model);
        }

        // POST: PolicyRisks/EditAllRiskSpecified/5
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
                var policyRisk = await _unitOfWork.PolicyRisks.GetByIdAsync(model.Id);
                policyRisk.Description = model.RiskItem;

                RiskItem riskItem = new()
                {
                    Id = model.RiskItemId,
                    Description = model.RiskItem
                };

                _unitOfWork.PolicyRisks.Update(model.PolicyRiskId, policyRisk);
                _unitOfWork.RiskItems.Update(model.RiskItemId, riskItem);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(PolicyRisk), new { policyRiskId = model.PolicyRiskId });
            }

            return View(model);
        }

        // POST: PolicyRisks/EditContent/5
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
                var policyRisk = await _unitOfWork.PolicyRisks.GetByIdAsync(model.Id);
                policyRisk.Description = model.PhysicalAddress;

                _unitOfWork.PolicyRisks.Update(model.PolicyRiskId, policyRisk);
                var content = _mapper.Map<ContentViewModel, Content>(model);
                _unitOfWork.Contents.Update(model.Id, content);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(PolicyRisk), new { policyRiskId = model.PolicyRiskId });
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

        // POST: PolicyRisks/EditHouse/5
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
                var policyRisk = await _unitOfWork.PolicyRisks.GetByIdAsync(model.Id);
                policyRisk.Description = model.PhysicalAddress;
                _unitOfWork.PolicyRisks.Update(model.PolicyRiskId, policyRisk);
                var house = _mapper.Map<HouseViewModel, House>(model);
                _unitOfWork.Houses.Update(model.Id, house);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(PolicyRisk), new { policyRiskId = model.PolicyRiskId });
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

        // POST: PolicyRisks/EditMotor/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMotor(MotorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var policyRisk = await _unitOfWork.PolicyRisks.GetByIdAsync(model.Id);
                var motorMake = await _unitOfWork.MotorMakes.GetById(model.MotorMakeId);
                policyRisk.Description = model.RegYear + " " + motorMake.Name + " " + model.RegNumber;


                _unitOfWork.PolicyRisks.Update(model.PolicyRiskId, policyRisk);
                var motor = _mapper.Map<MotorViewModel, Motor>(model);
                _unitOfWork.Motors.Update(model.Id, motor);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(PolicyRisk), new { policyRiskId = model.PolicyRiskId });
            }

            var bodyTypes = await _unitOfWork.BodyTypes.GetAll(r => r.OrderBy(n => n.Name));
            var driverTypes = await _unitOfWork.DriverTypes.GetAll(r => r.OrderBy(n => n.Name));
            var motorMakes = await _unitOfWork.MotorMakes.GetAll(r => r.OrderBy(n => n.Name));

            var selectedMotorModel = await _unitOfWork.MotorModels.GetById(model.MotorModelId);
            var selectedMotorMakeId = selectedMotorModel.MotorMakeId;
            var motorModels = await _unitOfWork.MotorModels.GetByMotorMakeId(selectedMotorMakeId);

            model.BodyTypeList = MVCHelperExtensions.ToSelectList(bodyTypes, model.BodyTypeId);
            model.DriverTypeList = MVCHelperExtensions.ToSelectList(driverTypes, model.DriverTypeId);
            model.MotorMakeList = MVCHelperExtensions.ToSelectList(motorMakes, selectedMotorMakeId);
            model.MotorModelList = MVCHelperExtensions.ToSelectList(motorModels, model.MotorModelId);

            return View(model);
        }

        // POST: PolicyRisks/EditTravel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTravel(TravelViewModel model)
        {
            if (ModelState.IsValid)
            {
                var policyRisk = await _unitOfWork.PolicyRisks.GetByIdAsync(model.Id);
                policyRisk.Description = model.Client.FirstName + " " + model.Client.FirstName;


                _unitOfWork.PolicyRisks.Update(model.PolicyRiskId, policyRisk);
                var travel = _mapper.Map<TravelViewModel, Travel>(model);
                _unitOfWork.Travels.Update(model.Id, travel);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(PolicyRisk), new { policyRiskId = model.PolicyRiskId });
            }

            return View(model);
        }

        // GET: PolicyRisks/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _unitOfWork.PolicyRisks.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<PolicyRisk, PolicyRiskViewModel>(result);
            var coverTypes = await _unitOfWork.CoverTypes.GetAll(r => r.OrderBy(n => n.Name));
            model.CoverTypeList = MVCHelperExtensions.ToSelectList(coverTypes, Guid.Empty);
            return View(model);
        }

        // POST: PolicyRisks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, PolicyRiskViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var policyRisk = _mapper.Map<PolicyRiskViewModel, PolicyRisk>(model);
                _unitOfWork.PolicyRisks.Update(policyRisk);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Edit), "Policy", new { Id = model.PolicyId });
            }

            var coverTypes = await _unitOfWork.CoverTypes.GetAll(r => r.OrderBy(n => n.Name));
            model.CoverTypeList = MVCHelperExtensions.ToSelectList(coverTypes, model.CoverTypeId);
            return View(model);
        }

        // GET: PolicyRisks/Detail/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _policyRiskService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // GET: PolicyRisks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _policyRiskService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // POST: PolicyRisks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(PolicyRiskViewModel ViewModel)
        {
            _policyRiskService.DeleteAsync(ViewModel.Id);
            return RedirectToAction(nameof(Edit), "Policy", new { ViewModel.PolicyId });
        }
    }
}
