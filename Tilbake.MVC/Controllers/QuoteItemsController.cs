using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    public class QuoteItemsController : Controller
    {
        private readonly IQuoteItemService _quoteItemService;
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
        private readonly IMotorUseService _motorUseService;

        public QuoteItemsController(IQuoteItemService quoteItemService,
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
                                    IMotorModelService motorModelService,
                                    IMotorUseService motorUseService)
        {
            _quoteItemService = quoteItemService;
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
            _motorUseService = motorUseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> QuoteItemRisk(Guid quoteItemId)
        {
            var resource = await _quoteItemService.GetRisksAsync(quoteItemId);
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
                allRiskResource.RiskItem = result.Description;
                model = allRiskResource;
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

                returnView = "QuoteHouse";
                HouseResource houseResource = resource.House;
                houseResource.QuoteItemId = quoteItemId;
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
                var motorUses = await _motorUseService.GetAllAsync();

                returnView = "QuoteMotor";
                MotorResource motorResource = resource.Motor;

                var selectedMotorModel = await _motorModelService.GetByIdAsync(motorResource.MotorModelId);
                var selectedMotorMakeId = selectedMotorModel.MotorMakeId;
                var motorModels = await _motorModelService.GetByMotorMakeIdAsync(selectedMotorMakeId);

                motorResource.QuoteItemId = quoteItemId;
                motorResource.BodyTypeList = new SelectList(bodyTypes, "Id", "Name", motorResource.BodyTypeId);
                motorResource.DriverTypeList = new SelectList(driverTypes, "Id", "Name", motorResource.DriverTypeId);
                motorResource.MotorMakeList = new SelectList(motorMakes, "Id", "Name", selectedMotorMakeId);
                motorResource.MotorModelList = new SelectList(motorModels, "Id", "Name", motorResource.MotorModelId);
                motorResource.MotorUseList = new SelectList(motorUses, "Id", "Name", motorResource.MotorUseId);
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
                    quoteItemResource.Description = resource.RiskItem;

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
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(QuoteItemRisk), new { quoteItemId = resource.QuoteItemId });
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
                    quoteItemResource.Description = resource.Name;

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
                    quoteItemResource.Description = resource.PhysicalAddress;

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
                    quoteItemResource.Description = resource.RegYear + " " + motorMake.Name + " " + resource.RegNumber;

                    QuoteItemMotorResource quoteItemMotorResource = new()
                    {
                        QuoteItem = quoteItemResource,
                        Motor = resource
                    };
                    await _quoteItemService.UpdateQuoteItemMotorAsync(quoteItemMotorResource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(QuoteItemRisk), new { quoteItemId = resource.QuoteItemId });
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

            var resource = await _quoteItemService.GetFirstOrDefaultAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            var coverTypes = await _coverTypeService.GetAllAsync();

            resource.CoverTypeList = new SelectList(coverTypes, "Id", "Name");

            return await Task.Run(() => View(resource)).ConfigureAwait(true);
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

                return RedirectToAction(nameof(Edit), "Quotes", new { Id = resource.QuoteId });
            }
            return View(resource);
        }

        // GET: QuoteItems/Detail/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _quoteItemService.GetFirstOrDefaultAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return await Task.Run(() => View(resource)).ConfigureAwait(true);
        }

        // GET: QuoteItems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _quoteItemService.GetFirstOrDefaultAsync((Guid)id);
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
