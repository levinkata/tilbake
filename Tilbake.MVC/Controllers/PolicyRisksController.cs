using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class PolicyRisksController : Controller
    {
        private readonly IPolicyRiskService _policyRiskService;

        private readonly ICoverTypeService _coverTypeService;
        private readonly IHouseService _houseService;
        private readonly IHouseConditionService _houseConditionService;

        private readonly IContentService _contentService;
        private readonly IResidenceTypeService _residenceTypeService;
        private readonly IResidenceUseService _residenceUseService;
        private readonly IRoofTypeService _roofTypeService;
        private readonly IWallTypeService _wallTypeService;

        private readonly IAllRiskService _allRiskService;
        private readonly IRiskItemService _riskItemService;
        private readonly IMotorService _motorService;
        private readonly IBodyTypeService _bodyTypeService;
        private readonly IDriverTypeService _driverTypeService;
        private readonly IMotorMakeService _motorMakeService;
        private readonly IMotorModelService _motorModelService;

        public PolicyRisksController(IPolicyRiskService policyRiskService,
                                    ICoverTypeService coverTypeService,
                                    IHouseService houseService,
                                    IHouseConditionService houseConditionService,
                                    IContentService contentService,
                                    IResidenceTypeService residenceTypeService,
                                    IResidenceUseService residenceUseService,
                                    IRoofTypeService roofTypeService,
                                    IWallTypeService wallTypeService,
                                    IAllRiskService allRiskService,
                                    IRiskItemService riskItemService,
                                    IMotorService motorService,
                                    IBodyTypeService bodyTypeService,
                                    IDriverTypeService driverTypeService,
                                    IMotorMakeService motorMakeService,
                                    IMotorModelService motorModelService)
        {
            _policyRiskService = policyRiskService;

            _coverTypeService = coverTypeService;

            _houseService = houseService;
            _houseConditionService = houseConditionService;

            _contentService = contentService;
            _residenceTypeService = residenceTypeService;
            _residenceUseService = residenceUseService;
            _roofTypeService = roofTypeService;
            _wallTypeService = wallTypeService;

            _allRiskService = allRiskService;
            _riskItemService = riskItemService;

            _motorService = motorService;
            _bodyTypeService = bodyTypeService;
            _driverTypeService = driverTypeService;
            _motorMakeService = motorMakeService;
            _motorModelService = motorModelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> PolicyRisk(Guid policyRiskId)
        {
            var ViewModel = await _policyRiskService.GetRisksAsync(policyRiskId);
            if (ViewModel == null)
            {
                return NotFound();
            }

            var returnView = "";
            object model = null;

            if (ViewModel.AllRisk != null)
            {
                returnView = "PolicyRiskAllRisk";
                AllRiskViewModel allRiskViewModel = ViewModel.AllRisk;
                var riskItem = allRiskViewModel.RiskItemId;
                var result = await _riskItemService.GetByIdAsync(riskItem);

                allRiskViewModel.PolicyRiskId = policyRiskId;
                allRiskViewModel.RiskItem = result.Description;
                model = allRiskViewModel;
            }

            if (ViewModel.Content != null)
            {
                var residenceTypes = await _residenceTypeService.GetAllAsync();
                var residenceUses = await _residenceUseService.GetAllAsync();
                var roofTypes = await _roofTypeService.GetAllAsync();
                var wallTypes = await _wallTypeService.GetAllAsync();

                returnView = "PolicyRiskContent";
                ContentViewModel contentViewModel = ViewModel.Content;
                contentViewModel.PolicyRiskId = policyRiskId;
                contentViewModel.ResidenceTypeList = new SelectList(residenceTypes, "Id", "Name", contentViewModel.ResidenceTypeId);
                contentViewModel.ResidenceUseList = new SelectList(residenceUses, "Id", "Name", contentViewModel.ResidenceUseId);
                contentViewModel.RoofTypeList = new SelectList(roofTypes, "Id", "Name", contentViewModel.RoofTypeId);
                contentViewModel.WallTypeList = new SelectList(wallTypes, "Id", "Name", contentViewModel.WallTypeId);
                model = contentViewModel;
            }

            if (ViewModel.House != null)
            {
                var residenceTypes = await _residenceTypeService.GetAllAsync();
                var houseConditions = await _houseConditionService.GetAllAsync();
                var roofTypes = await _roofTypeService.GetAllAsync();
                var wallTypes = await _wallTypeService.GetAllAsync();

                returnView = "PolicyRiskHouse";
                HouseViewModel houseViewModel = ViewModel.House;
                houseViewModel.PolicyRiskId = policyRiskId;
                houseViewModel.ResidenceTypeList = new SelectList(residenceTypes, "Id", "Name", houseViewModel.ResidenceTypeId);
                houseViewModel.HouseConditionList = new SelectList(houseConditions, "Id", "Name", houseViewModel.HouseConditionId);
                houseViewModel.RoofTypeList = new SelectList(roofTypes, "Id", "Name", houseViewModel.RoofTypeId);
                houseViewModel.WallTypeList = new SelectList(wallTypes, "Id", "Name", houseViewModel.WallTypeId);
                model = houseViewModel;
            }

            if (ViewModel.Motor != null)
            {
                var bodyTypes = await _bodyTypeService.GetAllAsync();
                var driverTypes = await _driverTypeService.GetAllAsync();
                var motorMakes = await _motorMakeService.GetAllAsync();

                returnView = "PolicyRiskMotor";
                MotorViewModel motorViewModel = ViewModel.Motor;

                var selectedMotorModel = await _motorModelService.GetByIdAsync(motorViewModel.MotorModelId);
                var selectedMotorMakeId = selectedMotorModel.MotorMakeId;
                var motorModels = await _motorModelService.GetByMotorMakeIdAsync(selectedMotorMakeId);

                motorViewModel.PolicyRiskId = policyRiskId;
                motorViewModel.BodyTypeList = new SelectList(bodyTypes, "Id", "Name", motorViewModel.BodyTypeId);
                motorViewModel.DriverTypeList = new SelectList(driverTypes, "Id", "Name", motorViewModel.DriverTypeId);
                motorViewModel.MotorMakeList = new SelectList(motorMakes, "Id", "Name", selectedMotorMakeId);
                motorViewModel.MotorModelList = new SelectList(motorModels, "Id", "Name", motorViewModel.MotorModelId);
                model = motorViewModel;
            }

            return View(returnView, model);
        }


        // POST: PolicyRisks/EditAllRisk/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllRisk(Guid? id, AllRiskViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var policyRiskViewModel = await _policyRiskService.GetByIdAsync(ViewModel.Id);
                    policyRiskViewModel.Description = ViewModel.RiskItem;

                    RiskItemViewModel riskViewModel = new()
                    {
                        Id = ViewModel.RiskItemId,
                        Description = ViewModel.RiskItem
                    };

                    PolicyRiskRiskItemViewModel policyRiskRiskItemViewModel = new()
                    {
                        PolicyRisk = policyRiskViewModel,
                        RiskItem = riskViewModel
                    };
                    await _policyRiskService.UpdatePolicyRiskRiskItem(policyRiskRiskItemViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(PolicyRisk), new { policyRiskId = ViewModel.PolicyRiskId });
            }

            return View(ViewModel);
        }

        // POST: PolicyRisks/EditContent/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditContent(Guid? id, ContentViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var policyRiskViewModel = await _policyRiskService.GetByIdAsync(ViewModel.PolicyRiskId);
                    policyRiskViewModel.Description = ViewModel.PhysicalAddress;

                    PolicyRiskContentViewModel policyRiskContentViewModel = new()
                    {
                        PolicyRisk = policyRiskViewModel,
                        Content = ViewModel
                    };
                    await _policyRiskService.UpdatePolicyRiskContent(policyRiskContentViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(PolicyRisk), new { policyRiskId = ViewModel.PolicyRiskId });
            }

            return View(ViewModel);
        }

        // POST: PolicyRisks/EditHouse/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHouse(Guid? id, HouseViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var policyRiskViewModel = await _policyRiskService.GetByIdAsync(ViewModel.PolicyRiskId);
                    policyRiskViewModel.Description = ViewModel.PhysicalAddress;

                    PolicyRiskHouseViewModel policyRiskHouseViewModel = new()
                    {
                        PolicyRisk = policyRiskViewModel,
                        House = ViewModel
                    };
                    await _policyRiskService.UpdatePolicyRiskHouse(policyRiskHouseViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(PolicyRisk), new { policyRiskId = ViewModel.PolicyRiskId });
            }

            return View(ViewModel);
        }

        // POST: PolicyRisks/EditMotor/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMotor(MotorViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var policyRiskViewModel = await _policyRiskService.GetByIdAsync(ViewModel.PolicyRiskId);

                    var motorMake = await _motorMakeService.GetByIdAsync(ViewModel.MotorMakeId);
                    policyRiskViewModel.Description = ViewModel.RegYear + " " + motorMake.Name + " " + ViewModel.RegNumber;

                    PolicyRiskMotorViewModel policyRiskMotorViewModel = new()
                    {
                        PolicyRisk = policyRiskViewModel,
                        Motor = ViewModel
                    };
                    await _policyRiskService.UpdatePolicyRiskMotor(policyRiskMotorViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(PolicyRisk), new { policyRiskId = ViewModel.PolicyRiskId });
            }

            var bodyTypes = await _bodyTypeService.GetAllAsync();
            var driverTypes = await _driverTypeService.GetAllAsync();
            var motorMakes = await _motorMakeService.GetAllAsync();
            var motorModels = await _motorModelService.GetByMotorMakeIdAsync(ViewModel.MotorMakeId);

            ViewModel.BodyTypeList = new SelectList(bodyTypes, "Id", "Name", ViewModel.BodyTypeId);
            ViewModel.DriverTypeList = new SelectList(driverTypes, "Id", "Name", ViewModel.DriverTypeId);
            ViewModel.MotorMakeList = new SelectList(motorMakes, "Id", "Name", ViewModel.MotorMakeId);
            ViewModel.MotorModelList = new SelectList(motorModels, "Id", "Name", ViewModel.MotorModelId);

            return View(ViewModel);
        }

        // GET: PolicyRisks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
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

            var coverTypes = await _coverTypeService.GetAllAsync();
            ViewModel.CoverTypeList = new SelectList(coverTypes, "Id", "Name");

            return await Task.Run(() => View(ViewModel));
        }

        // POST: PolicyRisks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid? id, PolicyRiskViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _policyRiskService.UpdateAsync(ViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction(nameof(Edit), "Policy", new { Id = ViewModel.PolicyId });
            }
            return View(ViewModel);
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
