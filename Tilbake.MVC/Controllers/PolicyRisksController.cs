using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

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
            var resource = await _policyRiskService.GetRisksAsync(policyRiskId);
            if (resource == null)
            {
                return NotFound();
            }

            var returnView = "";
            object model = null;

            if (resource.AllRisk != null)
            {
                returnView = "PolicyRiskAllRisk";
                AllRiskResource allRiskResource = resource.AllRisk;
                var riskItem = allRiskResource.RiskItemId;
                var result = await _riskItemService.GetByIdAsync(riskItem);

                allRiskResource.PolicyRiskId = policyRiskId;
                allRiskResource.RiskItem = result.Description;
                model = allRiskResource;
            }

            if (resource.Content != null)
            {
                var residenceTypes = await _residenceTypeService.GetAllAsync();
                var residenceUses = await _residenceUseService.GetAllAsync();
                var roofTypes = await _roofTypeService.GetAllAsync();
                var wallTypes = await _wallTypeService.GetAllAsync();

                returnView = "PolicyRiskContent";
                ContentResource contentResource = resource.Content;
                contentResource.PolicyRiskId = policyRiskId;
                contentResource.ResidenceTypeList = new SelectList(residenceTypes, "Id", "Name", contentResource.ResidenceTypeId);
                contentResource.ResidenceUseList = new SelectList(residenceUses, "Id", "Name", contentResource.ResidenceUseId);
                contentResource.RoofTypeList = new SelectList(roofTypes, "Id", "Name", contentResource.RoofTypeId);
                contentResource.WallTypeList = new SelectList(wallTypes, "Id", "Name", contentResource.WallTypeId);
                model = contentResource;
            }

            if (resource.House != null)
            {
                var residenceTypes = await _residenceTypeService.GetAllAsync();
                var houseConditions = await _houseConditionService.GetAllAsync();
                var roofTypes = await _roofTypeService.GetAllAsync();
                var wallTypes = await _wallTypeService.GetAllAsync();

                returnView = "PolicyRiskHouse";
                HouseResource houseResource = resource.House;
                houseResource.PolicyRiskId = policyRiskId;
                houseResource.ResidenceTypeList = new SelectList(residenceTypes, "Id", "Name", houseResource.ResidenceTypeId);
                houseResource.HouseConditionList = new SelectList(houseConditions, "Id", "Name", houseResource.HouseConditionId);
                houseResource.RoofTypeList = new SelectList(roofTypes, "Id", "Name", houseResource.RoofTypeId);
                houseResource.WallTypeList = new SelectList(wallTypes, "Id", "Name", houseResource.WallTypeId);
                model = houseResource;
            }

            if (resource.Motor != null)
            {
                var bodyTypes = await _bodyTypeService.GetAllAsync();
                var driverTypes = await _driverTypeService.GetAllAsync();
                var motorMakes = await _motorMakeService.GetAllAsync();

                returnView = "PolicyRiskMotor";
                MotorResource motorResource = resource.Motor;

                var selectedMotorModel = await _motorModelService.GetByIdAsync(motorResource.MotorModelId);
                var selectedMotorMakeId = selectedMotorModel.MotorMakeId;
                var motorModels = await _motorModelService.GetByMotorMakeIdAsync(selectedMotorMakeId);

                motorResource.PolicyRiskId = policyRiskId;
                motorResource.BodyTypeList = new SelectList(bodyTypes, "Id", "Name", motorResource.BodyTypeId);
                motorResource.DriverTypeList = new SelectList(driverTypes, "Id", "Name", motorResource.DriverTypeId);
                motorResource.MotorMakeList = new SelectList(motorMakes, "Id", "Name", selectedMotorMakeId);
                motorResource.MotorModelList = new SelectList(motorModels, "Id", "Name", motorResource.MotorModelId);
                model = motorResource;
            }

            return View(returnView, model);
        }


        // POST: PolicyRisks/EditAllRisk/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllRisk(Guid? id, AllRiskResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var policyRiskResource = await _policyRiskService.GetByIdAsync(resource.Id);
                    policyRiskResource.Description = resource.RiskItem;

                    RiskItemResource riskResource = new()
                    {
                        Id = resource.RiskItemId,
                        Description = resource.RiskItem
                    };

                    PolicyRiskRiskItemResource policyRiskRiskItemResource = new()
                    {
                        PolicyRisk = policyRiskResource,
                        RiskItem = riskResource
                    };
                    await _policyRiskService.UpdatePolicyRiskRiskItemAsync(policyRiskRiskItemResource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(PolicyRisk), new { policyRiskId = resource.PolicyRiskId });
            }

            return View(resource);
        }

        // POST: PolicyRisks/EditContent/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditContent(Guid? id, ContentResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var policyRiskResource = await _policyRiskService.GetByIdAsync(resource.PolicyRiskId);
                    policyRiskResource.Description = resource.PhysicalAddress;

                    PolicyRiskContentResource policyRiskContentResource = new()
                    {
                        PolicyRisk = policyRiskResource,
                        Content = resource
                    };
                    await _policyRiskService.UpdatePolicyRiskContentAsync(policyRiskContentResource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(PolicyRisk), new { policyRiskId = resource.PolicyRiskId });
            }

            return View(resource);
        }

        // POST: PolicyRisks/EditHouse/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHouse(Guid? id, HouseResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var policyRiskResource = await _policyRiskService.GetByIdAsync(resource.PolicyRiskId);
                    policyRiskResource.Description = resource.PhysicalAddress;

                    PolicyRiskHouseResource policyRiskHouseResource = new()
                    {
                        PolicyRisk = policyRiskResource,
                        House = resource
                    };
                    await _policyRiskService.UpdatePolicyRiskHouseAsync(policyRiskHouseResource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(PolicyRisk), new { policyRiskId = resource.PolicyRiskId });
            }

            return View(resource);
        }

        // POST: PolicyRisks/EditMotor/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMotor(MotorResource resource)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var policyRiskResource = await _policyRiskService.GetByIdAsync(resource.PolicyRiskId);

                    var motorMake = await _motorMakeService.GetByIdAsync(resource.MotorMakeId);
                    policyRiskResource.Description = resource.RegYear + " " + motorMake.Name + " " + resource.RegNumber;

                    PolicyRiskMotorResource policyRiskMotorResource = new()
                    {
                        PolicyRisk = policyRiskResource,
                        Motor = resource
                    };
                    await _policyRiskService.UpdatePolicyRiskMotorAsync(policyRiskMotorResource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(PolicyRisk), new { policyRiskId = resource.PolicyRiskId });
            }

            var bodyTypes = await _bodyTypeService.GetAllAsync();
            var driverTypes = await _driverTypeService.GetAllAsync();
            var motorMakes = await _motorMakeService.GetAllAsync();
            var motorModels = await _motorModelService.GetByMotorMakeIdAsync(resource.MotorMakeId);

            resource.BodyTypeList = new SelectList(bodyTypes, "Id", "Name", resource.BodyTypeId);
            resource.DriverTypeList = new SelectList(driverTypes, "Id", "Name", resource.DriverTypeId);
            resource.MotorMakeList = new SelectList(motorMakes, "Id", "Name", resource.MotorMakeId);
            resource.MotorModelList = new SelectList(motorModels, "Id", "Name", resource.MotorModelId);

            return View(resource);
        }

        // GET: PolicyRisks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _policyRiskService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            var coverTypes = await _coverTypeService.GetAllAsync();
            resource.CoverTypeList = new SelectList(coverTypes, "Id", "Name");

            return await Task.Run(() => View(resource));
        }

        // POST: PolicyRisks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, PolicyRiskResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _policyRiskService.UpdateAsync(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction(nameof(Edit), "Policy", new { Id = resource.PolicyId });
            }
            return View(resource);
        }

        // GET: PolicyRisks/Detail/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _policyRiskService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // GET: PolicyRisks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _policyRiskService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: PolicyRisks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(PolicyRiskResource resource)
        {
            await _policyRiskService.DeleteAsync(resource.Id);
            return RedirectToAction(nameof(Edit), "Policy", new { resource.PolicyId });
        }
    }
}
