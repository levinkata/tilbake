using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

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

        private readonly IExcessBuyBackService _excessBuyBackService;

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

        public QuoteItemsController(IQuoteItemService quoteItemService,
                                    ICoverTypeService coverTypeService,
                                    IBuildingService buildingService,
                                    IBuildingConditionService buildingConditionService,
                                    IHouseService houseService,
                                    IHouseConditionService houseConditionService,
                                    IExcessBuyBackService excessBuyBackService,
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
            _quoteItemService = quoteItemService;
            _coverTypeService = coverTypeService;

            _buildingService = buildingService;
            _buildingConditionService = buildingConditionService;

            _houseService = houseService;
            _houseConditionService = houseConditionService;

            _contentService = contentService;
            _excessBuyBackService = excessBuyBackService;
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

        public async Task<IActionResult> QuoteItemRisk(Guid quoteItemId)
        {
            var ViewModel = await _quoteItemService.GetRisksAsync(quoteItemId);
            var quote = await _quoteItemService.GetByIdAsync(quoteItemId);

            if (ViewModel == null)
            {
                return NotFound();
            }

            var returnView = "";
            object model = null;

            //  AllRisk
            if (ViewModel.AllRisk != null)
            {
                returnView = "QuoteAllRisk";
                AllRiskViewModel allRiskViewModel = ViewModel.AllRisk;
                var riskItem = allRiskViewModel.RiskItemId;
                var result = await _riskItemService.GetByIdAsync(riskItem);

                allRiskViewModel.QuoteItemId = quoteItemId;
                allRiskViewModel.QuoteId = quote.QuoteId;
                allRiskViewModel.RiskItem = result.Description;
                model = allRiskViewModel;
            }

            //  Building
            if (ViewModel.Building != null)
            {
                var residenceTypes = await _residenceTypeService.GetAllAsync();
                var residenceUses = await _residenceUseService.GetAllAsync();
                var buildingConditions = await _buildingConditionService.GetAllAsync();
                var roofTypes = await _roofTypeService.GetAllAsync();
                var wallTypes = await _wallTypeService.GetAllAsync();

                returnView = "QuoteBuilding";
                BuildingViewModel buildingViewModel = ViewModel.Building;
                buildingViewModel.QuoteItemId = quoteItemId;
                buildingViewModel.QuoteId = quote.QuoteId;
                buildingViewModel.ResidenceTypeList = SelectLists.ResidenceTypes(residenceTypes, buildingViewModel.ResidenceTypeId);
                buildingViewModel.ResidenceUseList = SelectLists.ResidenceUses(residenceUses, buildingViewModel.ResidenceUseId);
                buildingViewModel.BuildingConditionList = SelectLists.BuildingConditions(buildingConditions, buildingViewModel.BuildingConditionId);
                buildingViewModel.RoofTypeList = SelectLists.RoofTypes(roofTypes, buildingViewModel.RoofTypeId);
                buildingViewModel.WallTypeList = SelectLists.WallTypes(wallTypes, buildingViewModel.WallTypeId);
                model = buildingViewModel;
            }

            //  Content
            if (ViewModel.Content != null)
            {
                var residenceTypes = await _residenceTypeService.GetAllAsync();
                var residenceUses = await _residenceUseService.GetAllAsync();
                var roofTypes = await _roofTypeService.GetAllAsync();
                var wallTypes = await _wallTypeService.GetAllAsync();

                returnView = "QuoteContent";
                ContentViewModel contentViewModel = ViewModel.Content;
                contentViewModel.QuoteItemId = quoteItemId;
                contentViewModel.QuoteId = quote.QuoteId;
                contentViewModel.ResidenceTypeList = SelectLists.ResidenceTypes(residenceTypes, contentViewModel.ResidenceTypeId);
                contentViewModel.ResidenceUseList = SelectLists.ResidenceUses(residenceUses, contentViewModel.ResidenceUseId);
                contentViewModel.RoofTypeList = SelectLists.RoofTypes(roofTypes, contentViewModel.RoofTypeId);
                contentViewModel.WallTypeList = SelectLists.WallTypes(wallTypes, contentViewModel.WallTypeId);
                model = contentViewModel;
            }

            //  ExcessBuyBack
            if (ViewModel.ExcessBuyBack != null)
            {

                returnView = "QuoteExcessBuyBack";
                ExcessBuyBackViewModel excessBuyBackViewModel = ViewModel.ExcessBuyBack;
                excessBuyBackViewModel.QuoteItemId = quoteItemId;
                excessBuyBackViewModel.QuoteId = quote.QuoteId;
                model = excessBuyBackViewModel;
            }

            //  House
            if (ViewModel.House != null)
            {
                var residenceTypes = await _residenceTypeService.GetAllAsync();
                var houseConditions = await _houseConditionService.GetAllAsync();
                var roofTypes = await _roofTypeService.GetAllAsync();
                var wallTypes = await _wallTypeService.GetAllAsync();

                returnView = "QuoteHouse";
                HouseViewModel houseViewModel = ViewModel.House;
                houseViewModel.QuoteItemId = quoteItemId;
                houseViewModel.QuoteId = quote.QuoteId;
                houseViewModel.ResidenceTypeList = SelectLists.ResidenceTypes(residenceTypes, houseViewModel.ResidenceTypeId);
                houseViewModel.HouseConditionList = SelectLists.HouseConditions(houseConditions, houseViewModel.HouseConditionId);
                houseViewModel.RoofTypeList = SelectLists.RoofTypes(roofTypes, houseViewModel.RoofTypeId);
                houseViewModel.WallTypeList = SelectLists.WallTypes(wallTypes, houseViewModel.WallTypeId);
                model = houseViewModel;
            }

            //  Motor
            if (ViewModel.Motor != null)
            {
                var bodyTypes = await _bodyTypeService.GetAllAsync();
                var driverTypes = await _driverTypeService.GetAllAsync();
                var motorMakes = await _motorMakeService.GetAllAsync();

                returnView = "QuoteMotor";
                MotorViewModel motorViewModel = ViewModel.Motor;

                var selectedMotorModel = await _motorModelService.GetByIdAsync(motorViewModel.MotorModelId);
                var selectedMotorMakeId = selectedMotorModel.MotorMakeId;
                var motorModels = await _motorModelService.GetByMotorMakeIdAsync(selectedMotorMakeId);

                motorViewModel.QuoteItemId = quoteItemId;
                motorViewModel.QuoteId = quote.QuoteId;
                motorViewModel.MotorMakeId = selectedMotorMakeId;
                motorViewModel.BodyTypeList = SelectLists.BodyTypes(bodyTypes, motorViewModel.BodyTypeId);
                motorViewModel.DriverTypeList = SelectLists.DriverTypes(driverTypes, motorViewModel.DriverTypeId);
                motorViewModel.MotorMakeList = SelectLists.MotorMakes(motorMakes, selectedMotorMakeId);
                motorViewModel.MotorModelList = SelectLists.MotorModels(motorModels, motorViewModel.MotorModelId);
                motorViewModel.DateRangeList = SelectLists.RegisteredYears(motorViewModel.RegYear);

                model = motorViewModel;
            }

            return View(returnView, model);
        }


        // POST: QuoteItems/EditAllRisk/5
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
                    var quoteItemViewModel = await _quoteItemService.GetByIdAsync(ViewModel.QuoteItemId);
                    quoteItemViewModel.Description = "AllRisks - " + ViewModel.RiskItem;

                    RiskItemViewModel riskViewModel = new()
                    {
                        Id = ViewModel.RiskItemId,
                        Description = ViewModel.RiskItem
                    };

                    QuoteItemRiskItemViewModel quoteItemRiskItemViewModel = new()
                    {
                        QuoteItem = quoteItemViewModel,
                        RiskItem = riskViewModel
                    };
                    await _quoteItemService.UpdateQuoteItemRiskItem(quoteItemRiskItemViewModel);
                    return RedirectToAction(nameof(Details), "Quotes", new { id = quoteItemViewModel.QuoteId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

            }

            return View(ViewModel);
        }

        // POST: QuoteItems/EditBuilding/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBuilding(Guid? id, BuildingViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var quoteItemViewModel = await _quoteItemService.GetByIdAsync(ViewModel.QuoteItemId);
                    quoteItemViewModel.Description = "Building - " + ViewModel.PhysicalAddress;

                    QuoteItemBuildingViewModel quoteItemBuildingViewModel = new()
                    {
                        QuoteItem = quoteItemViewModel,
                        Building = ViewModel
                    };
                    await _quoteItemService.UpdateQuoteItemBuilding(quoteItemBuildingViewModel);
                    return RedirectToAction(nameof(Details), "Quotes", new { id = quoteItemViewModel.QuoteId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            return View(ViewModel);
        }

        // POST: QuoteItems/EditContent/5
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
                    var quoteItemViewModel = await _quoteItemService.GetByIdAsync(ViewModel.QuoteItemId);
                    quoteItemViewModel.Description = "Contents - " + ViewModel.PhysicalAddress;

                    QuoteItemContentViewModel quoteItemContentViewModel = new()
                    {
                        QuoteItem = quoteItemViewModel,
                        Content = ViewModel
                    };
                    await _quoteItemService.UpdateQuoteItemContent(quoteItemContentViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(QuoteItemRisk), new { quoteItemId = ViewModel.QuoteItemId });
            }

            return View(ViewModel);
        }

        // POST: QuoteItems/EditHouse/5
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
                    var quoteItemViewModel = await _quoteItemService.GetByIdAsync(ViewModel.QuoteItemId);
                    quoteItemViewModel.Description = "House - " + ViewModel.PhysicalAddress;

                    QuoteItemHouseViewModel quoteItemHouseViewModel = new()
                    {
                        QuoteItem = quoteItemViewModel,
                        House = ViewModel
                    };
                    await _quoteItemService.UpdateQuoteItemHouse(quoteItemHouseViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(QuoteItemRisk), new { quoteItemId = ViewModel.QuoteItemId });
            }

            return View(ViewModel);
        }

        // POST: QuoteItems/EditMotor/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMotor(MotorViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var quoteItemViewModel = await _quoteItemService.GetByIdAsync(ViewModel.QuoteItemId);

                    var motorMake = await _motorMakeService.GetByIdAsync(ViewModel.MotorMakeId);
                    quoteItemViewModel.Description = "Motor - " + ViewModel.RegYear + " " + motorMake.Name + " " + ViewModel.RegNumber;

                    QuoteItemMotorViewModel quoteItemMotorViewModel = new()
                    {
                        QuoteItem = quoteItemViewModel,
                        Motor = ViewModel
                    };
                    await _quoteItemService.UpdateQuoteItemMotor(quoteItemMotorViewModel);
                    return RedirectToAction(nameof(Details), "Quotes", new { id = quoteItemViewModel.QuoteId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
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

        // GET: QuoteItems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _quoteItemService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            var coverTypes = await _coverTypeService.GetAllAsync();
            ViewModel.CoverTypeList = SelectLists.CoverTypes(coverTypes, Guid.Empty);

            return View(ViewModel);
        }

        // POST: QuoteItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, QuoteItemViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _quoteItemService.UpdateAsync(ViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction(nameof(Details), "Quotes", new { Id = ViewModel.QuoteId });
            }

            var coverTypes = await _coverTypeService.GetAllAsync();
            ViewModel.CoverTypeList = SelectLists.CoverTypes(coverTypes, ViewModel.CoverTypeId);
            return View(ViewModel);
        }

        // GET: QuoteItems/Detail/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _quoteItemService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // GET: QuoteItems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _quoteItemService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // POST: QuoteItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(QuoteItemViewModel ViewModel)
        {
            _quoteItemService.DeleteAsync(ViewModel.Id);
            return RedirectToAction(nameof(Edit), "Quotes", new { ViewModel.QuoteId });
        }
    }
}
