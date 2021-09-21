using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    public class QuoteItemsController : Controller
    {
        private readonly IQuoteItemService _quoteItemService;
        private readonly ICoverTypeService _coverTypeService;

        private readonly IBuildingService _buildingService;
        private readonly IBuildingConditionService _buildingConditionService;

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
        private readonly IMotorUseService _motorUseService;

        public QuoteItemsController(IQuoteItemService quoteItemService,
                                    ICoverTypeService coverTypeService,
                                    IBuildingService buildingService,
                                    IBuildingConditionService buildingConditionService,
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
                                    IMotorModelService motorModelService,
                                    IMotorUseService motorUseService)
        {
            _quoteItemService = quoteItemService;
            _coverTypeService = coverTypeService;

            _buildingService = buildingService;
            _buildingConditionService = buildingConditionService;

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
            _motorUseService = motorUseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> QuoteItemRisk(Guid quoteItemId)
        {
            var resource = await _quoteItemService.GetRisksAsync(quoteItemId);
            var quote = await _quoteItemService.GetByIdAsync(quoteItemId);

            if (resource == null)
            {
                return NotFound();
            }

            var returnView = "";
            object model = null;

            if (resource.AllRisk != null)
            {
                returnView = "QuoteAllRisk";
                AllRiskResource allRiskResource = resource.AllRisk;
                var riskItem = allRiskResource.RiskItemId;
                var result = await _riskItemService.GetByIdAsync(riskItem);

                allRiskResource.QuoteItemId = quoteItemId;
                allRiskResource.QuoteId = quote.QuoteId;
                allRiskResource.RiskItem = result.Description;
                model = allRiskResource;
            }

            if (resource.Building != null)
            {
                var residenceTypes = await _residenceTypeService.GetAllAsync();
                var residenceUses = await _residenceUseService.GetAllAsync();
                var buildingConditions = await _buildingConditionService.GetAllAsync();
                var roofTypes = await _roofTypeService.GetAllAsync();
                var wallTypes = await _wallTypeService.GetAllAsync();

                returnView = "QuoteBuilding";
                BuildingResource buildingResource = resource.Building;
                buildingResource.QuoteItemId = quoteItemId;
                buildingResource.QuoteId = quote.QuoteId;
                buildingResource.ResidenceTypeList = SelectLists.ResidenceTypes(residenceTypes, buildingResource.ResidenceTypeId);
                buildingResource.ResidenceUseList = SelectLists.ResidenceUses(residenceUses, buildingResource.ResidenceUseId);
                buildingResource.BuildingConditionList = SelectLists.BuildingConditions(buildingConditions, buildingResource.BuildingConditionId);
                buildingResource.RoofTypeList = SelectLists.RoofTypes(roofTypes, buildingResource.RoofTypeId);
                buildingResource.WallTypeList = SelectLists.WallTypes(wallTypes, buildingResource.WallTypeId);
                model = buildingResource;
            }

            if (resource.Content != null)
            {
                var residenceTypes = await _residenceTypeService.GetAllAsync();
                var residenceUses = await _residenceUseService.GetAllAsync();
                var roofTypes = await _roofTypeService.GetAllAsync();
                var wallTypes = await _wallTypeService.GetAllAsync();

                returnView = "QuoteContent";
                ContentResource contentResource = resource.Content;
                contentResource.QuoteItemId = quoteItemId;
                contentResource.QuoteId = quote.QuoteId;
                contentResource.ResidenceTypeList = SelectLists.ResidenceTypes(residenceTypes, contentResource.ResidenceTypeId);
                contentResource.ResidenceUseList = SelectLists.ResidenceUses(residenceUses, contentResource.ResidenceUseId);
                contentResource.RoofTypeList = SelectLists.RoofTypes(roofTypes, contentResource.RoofTypeId);
                contentResource.WallTypeList = SelectLists.WallTypes(wallTypes, contentResource.WallTypeId);
                model = contentResource;
            }

            if (resource.House != null)
            {
                var residenceTypes = await _residenceTypeService.GetAllAsync();
                var houseConditions = await _houseConditionService.GetAllAsync();
                var roofTypes = await _roofTypeService.GetAllAsync();
                var wallTypes = await _wallTypeService.GetAllAsync();

                returnView = "QuoteHouse";
                HouseResource houseResource = resource.House;
                houseResource.QuoteItemId = quoteItemId;
                houseResource.QuoteId = quote.QuoteId;
                houseResource.ResidenceTypeList = SelectLists.ResidenceTypes(residenceTypes, houseResource.ResidenceTypeId);
                houseResource.HouseConditionList = SelectLists.HouseConditions(houseConditions, houseResource.HouseConditionId);
                houseResource.RoofTypeList = SelectLists.RoofTypes(roofTypes, houseResource.RoofTypeId);
                houseResource.WallTypeList = SelectLists.WallTypes(wallTypes, houseResource.WallTypeId);
                model = houseResource;
            }

            if (resource.Motor != null)
            {
                var bodyTypes = await _bodyTypeService.GetAllAsync();
                var driverTypes = await _driverTypeService.GetAllAsync();
                var motorMakes = await _motorMakeService.GetAllAsync();
                var motorUses = await _motorUseService.GetAllAsync();

                returnView = "QuoteMotor";
                MotorResource motorResource = resource.Motor;

                var selectedMotorModel = await _motorModelService.GetByIdAsync(motorResource.MotorModelId);
                var selectedMotorMakeId = selectedMotorModel.MotorMakeId;
                var motorModels = await _motorModelService.GetByMotorMakeIdAsync(selectedMotorMakeId);

                motorResource.QuoteItemId = quoteItemId;
                motorResource.QuoteId = quote.QuoteId;
                motorResource.MotorMakeId = selectedMotorMakeId;
                motorResource.BodyTypeList = SelectLists.BodyTypes(bodyTypes, motorResource.BodyTypeId);
                motorResource.DriverTypeList = SelectLists.DriverTypes(driverTypes, motorResource.DriverTypeId);
                motorResource.MotorMakeList = SelectLists.MotorMakes(motorMakes, selectedMotorMakeId);
                motorResource.MotorModelList = SelectLists.MotorModels(motorModels, motorResource.MotorModelId);
                motorResource.MotorUseList = SelectLists.MotorUses(motorUses, motorResource.MotorUseId);
                motorResource.DateRangeList = SelectLists.RegisteredYears(motorResource.RegYear);

                model = motorResource;
            }

            return View(returnView, model);
        }


        // POST: QuoteItems/EditAllRisk/5
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
                    var quoteItemResource = await _quoteItemService.GetByIdAsync(resource.QuoteItemId);
                    quoteItemResource.Description = "AllRisks - " + resource.RiskItem;

                    RiskItemResource riskResource = new()
                    {
                        Id = resource.RiskItemId,
                        Description = resource.RiskItem
                    };

                    QuoteItemRiskItemResource quoteItemRiskItemResource = new()
                    {
                        QuoteItem = quoteItemResource,
                        RiskItem = riskResource
                    };
                    await _quoteItemService.UpdateQuoteItemRiskItemAsync(quoteItemRiskItemResource);
                    return RedirectToAction(nameof(Details), "Quotes", new { id = quoteItemResource.QuoteId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

            }

            return View(resource);
        }

        // POST: QuoteItems/EditBuilding/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBuilding(Guid? id, BuildingResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var quoteItemResource = await _quoteItemService.GetByIdAsync(resource.QuoteItemId);
                    quoteItemResource.Description = "Building - " + resource.PhysicalAddress;

                    QuoteItemBuildingResource quoteItemBuildingResource = new()
                    {
                        QuoteItem = quoteItemResource,
                        Building = resource
                    };
                    await _quoteItemService.UpdateQuoteItemBuildingAsync(quoteItemBuildingResource);
                    return RedirectToAction(nameof(Details), "Quotes", new { id = quoteItemResource.QuoteId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            return View(resource);
        }

        // POST: QuoteItems/EditContent/5
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
                    var quoteItemResource = await _quoteItemService.GetByIdAsync(resource.QuoteItemId);
                    quoteItemResource.Description = "Contents - " + resource.PhysicalAddress;

                    QuoteItemContentResource quoteItemContentResource = new()
                    {
                        QuoteItem = quoteItemResource,
                        Content = resource
                    };
                    await _quoteItemService.UpdateQuoteItemContentAsync(quoteItemContentResource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(QuoteItemRisk), new { quoteItemId = resource.QuoteItemId });
            }

            return View(resource);
        }

        // POST: QuoteItems/EditHouse/5
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
                    var quoteItemResource = await _quoteItemService.GetByIdAsync(resource.QuoteItemId);
                    quoteItemResource.Description = "House - " + resource.PhysicalAddress;

                    QuoteItemHouseResource quoteItemHouseResource = new()
                    {
                        QuoteItem = quoteItemResource,
                        House = resource
                    };
                    await _quoteItemService.UpdateQuoteItemHouseAsync(quoteItemHouseResource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(QuoteItemRisk), new { quoteItemId = resource.QuoteItemId });
            }

            return View(resource);
        }

        // POST: QuoteItems/EditMotor/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMotor(MotorResource resource)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var quoteItemResource = await _quoteItemService.GetByIdAsync(resource.QuoteItemId);

                    var motorMake = await _motorMakeService.GetByIdAsync(resource.MotorMakeId);
                    quoteItemResource.Description = "Motor - " + resource.RegYear + " " + motorMake.Name + " " + resource.RegNumber;

                    QuoteItemMotorResource quoteItemMotorResource = new()
                    {
                        QuoteItem = quoteItemResource,
                        Motor = resource
                    };
                    await _quoteItemService.UpdateQuoteItemMotorAsync(quoteItemMotorResource);
                    return RedirectToAction(nameof(Details), "Quotes", new { id = quoteItemResource.QuoteId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            var bodyTypes = await _bodyTypeService.GetAllAsync();
            var driverTypes = await _driverTypeService.GetAllAsync();
            var motorMakes = await _motorMakeService.GetAllAsync();
            var motorModels = await _motorModelService.GetByMotorMakeIdAsync(resource.MotorMakeId);
            var motorUses = await _motorUseService.GetAllAsync();

            resource.BodyTypeList = new SelectList(bodyTypes, "Id", "Name", resource.BodyTypeId);
            resource.DriverTypeList = new SelectList(driverTypes, "Id", "Name", resource.DriverTypeId);
            resource.MotorMakeList = new SelectList(motorMakes, "Id", "Name", resource.MotorMakeId);
            resource.MotorModelList = new SelectList(motorModels, "Id", "Name", resource.MotorModelId);
            resource.MotorUseList = new SelectList(motorUses, "Id", "Name", resource.MotorUseId);

            return View(resource);
        }

        // GET: QuoteItems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _quoteItemService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            var coverTypes = await _coverTypeService.GetAllAsync();
            resource.CoverTypeList = SelectLists.CoverTypes(coverTypes, Guid.Empty);

            return View(resource);
        }

        // POST: QuoteItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, QuoteItemResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _quoteItemService.UpdateAsync(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction(nameof(Details), "Quotes", new { Id = resource.QuoteId });
            }

            var coverTypes = await _coverTypeService.GetAllAsync();
            resource.CoverTypeList = SelectLists.CoverTypes(coverTypes, resource.CoverTypeId);
            return View(resource);
        }

        // GET: QuoteItems/Detail/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _quoteItemService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // GET: QuoteItems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _quoteItemService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: QuoteItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(QuoteItemResource resource)
        {
            await _quoteItemService.DeleteAsync(resource.Id);
            return RedirectToAction(nameof(Edit), "Quotes", new { resource.QuoteId });
        }
    }
}
