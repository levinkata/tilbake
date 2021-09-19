using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    [Authorize]
    public class QuotesController : Controller
    {
        private readonly IQuoteService _quoteService;
        private readonly IBuildingConditionService _buildingConditionService;
        private readonly ICoverTypeService _coverTypeService;
        private readonly IInsurerService _insurerService;
        private readonly IQuoteStatusService _quoteStatusService;
        private readonly IBodyTypeService _bodyTypeService;
        private readonly IDriverTypeService _driverTypeService;
        private readonly IHouseConditionService _houseConditionService;
        private readonly IMotorMakeService _motorMakeService;
        private readonly IMotorModelService _motorModelService;
        private readonly IMotorUseService _motorUseService;
        private readonly IResidenceTypeService _residenceTypeService;
        private readonly IResidenceUseService _residenceUseService;
        private readonly IRoofTypeService _roofTypeService;
        private readonly IWallTypeService _wallTypeService;
        private readonly IPortfolioClientService _portfolioClientService;
        private readonly IPortfolioService _portfolioService;

        public QuotesController(IQuoteService quoteService,
                                IBuildingConditionService buildingConditionService,
                                ICoverTypeService coverTypeService,
                                IInsurerService insurerService,
                                IQuoteStatusService quoteStatusService,
                                IBodyTypeService bodyTypeService,
                                IDriverTypeService driverTypeService,
                                IHouseConditionService houseConditionService,
                                IMotorMakeService motorMakeService,
                                IMotorModelService motorModelService,
                                IMotorUseService motorUseService,
                                IResidenceTypeService residenceTypeService,
                                IResidenceUseService residenceUseService,
                                IRoofTypeService roofTypeService,
                                IWallTypeService wallTypeService,
                                IPortfolioClientService portfolioClientService,
                                IPortfolioService portfolioService)
        {
            _quoteService = quoteService;
            _buildingConditionService = buildingConditionService;
            _coverTypeService = coverTypeService;
            _insurerService = insurerService;
            _quoteStatusService = quoteStatusService;
            _bodyTypeService = bodyTypeService;
            _driverTypeService = driverTypeService;
            _houseConditionService = houseConditionService;
            _motorMakeService = motorMakeService;
            _motorModelService = motorModelService;
            _motorUseService = motorUseService;
            _residenceTypeService = residenceTypeService;
            _residenceUseService = residenceUseService;
            _roofTypeService = roofTypeService;
            _wallTypeService = wallTypeService;
            _portfolioClientService = portfolioClientService;
            _portfolioService = portfolioService;
        }

        // GET: Quotes
        public async Task<IActionResult> Index(Guid portfolioId)
        {
            var resources = await _quoteService.GetByPortfolioAsync(portfolioId);
            return View(resources);
        }

        public async Task<IActionResult> Search(Guid portfolioid, string searchString = "~#")
        {
            var resource = await _portfolioService.GetByIdAsync(portfolioid);
            var resources = await _quoteService.GetByPortfolioAsync(portfolioid);

            if (!String.IsNullOrEmpty(searchString))
            {
                var isNumeric = int.TryParse(searchString, out int quoteNumber);
                if (isNumeric)
                {
                    resources = resources.Where(r => r.QuoteNumber.Equals(quoteNumber));
                } else
                {
                    resources = resources.Where(r => r.Client.LastName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                            || r.Client.FirstName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                            || r.Client.IdNumber.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
                }
            }
            
            QuoteSearchResource searchResource = new()
            {
                PortfolioId = portfolioid,
                PortfolioName = resource.Name,
                SearchString = "",
                QuoteResources = resources.ToList()
            };
            return View(searchResource);
        }

        public async Task<IActionResult> Quotation()
        {
            return await Task.Run(() => View());
        }

        // GET: Quotes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var resource = await _quoteService.GetFirstOrDefaultAsync(id);
            if (resource == null)
            {
                return NotFound();
            }
            resource.IsConverted = await _quoteService.IsConvertedToPolicy(id);

            return View(resource);
        }
        
        [HttpPost]
        public async Task<IActionResult> PostQuote(QuoteObjectResource quoteObject)
        {
            if (quoteObject == null)
            {
                throw new ArgumentNullException(nameof(quoteObject));
            };

            await _quoteService.AddAsync(quoteObject);

            return Json(new { quoteObject.ClientId });
        }

        // GET: Quotes/Create
        public async Task<IActionResult> Create(Guid portfolioClientId)
        {
            var portfolioClient = await _portfolioClientService.GetByIdAsync(portfolioClientId);
            var clientId = portfolioClient.ClientId;
            var portfolioId = portfolioClient.PortfolioId;
            var client = portfolioClient.Client;

            var bodyTypes = await _bodyTypeService.GetAllAsync();
            var buildingConditions = await _buildingConditionService.GetAllAsync();
            var driverTypes = await _driverTypeService.GetAllAsync();
            var houseConditions = await _houseConditionService.GetAllAsync();
            var motorMakes = await _motorMakeService.GetAllAsync();
            var motorMakeId = motorMakes.FirstOrDefault().Id;
            var motorModels = await _motorModelService.GetByMotorMakeIdAsync(motorMakeId);
            var motorUses = await _motorUseService.GetAllAsync();
            var residenceTypes = await _residenceTypeService.GetAllAsync();
            var residenceUses = await _residenceUseService.GetAllAsync();
            var roofTypes = await _roofTypeService.GetAllAsync();
            var wallTypes = await _wallTypeService.GetAllAsync();

            var coverTypes = await _coverTypeService.GetAllAsync();
            var quoteStatuses = await _quoteStatusService.GetAllAsync();

            QuoteSaveResource resource = new()
            {
                PortfolioClientId = portfolioClientId,
                ClientId = clientId,
                PortfolioId = portfolioId,
                Client = client,
                BuildingConditionList = new SelectList(buildingConditions, "Id", "Name"),
                CoverTypeList = SelectLists.CoverTypes(coverTypes, Guid.Empty),
                QuoteStatusList = SelectLists.QuoteStatuses(quoteStatuses, Guid.Empty),
                BodyTypeList = SelectLists.BodyTypes(bodyTypes, Guid.Empty),
                DriverTypeList = new SelectList(driverTypes, "Id", "Name"),
                HouseConditionList = new SelectList(houseConditions, "Id", "Name"),
                MotorMakeList = new SelectList(motorMakes, "Id", "Name"),
                MotorModelList = new SelectList(motorModels, "Id", "Name"),
                MotorUseList = new SelectList(motorUses, "Id", "Name"),
                ResidenceTypeList = new SelectList(residenceTypes, "Id", "Name"),
                ResidenceUseList = new SelectList(residenceUses, "Id", "Name"),
                RoofTypeList = SelectLists.RoofTypes(roofTypes, Guid.Empty),
                WallTypeList = SelectLists.WallTypes(wallTypes, Guid.Empty),
                DateRangeList = new SelectList(DateRanges.Years(), "Value", "Text")
            };

            return View(resource);
        }

        // POST: Quotes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuoteObjectResource resource)
        {
            if (ModelState.IsValid)
            {
                await _quoteService.AddAsync(resource);
                return RedirectToAction(nameof(Details), "PortfolioClients", new { resource.Quote.PortfolioClientId });
            }

            return View(resource);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var resource = await _quoteService.GetByIdAsync(id);
            if (resource == null)
            {
                return NotFound();
            }

            var result = await _portfolioClientService.GetByIdAsync(resource.PortfolioClientId);
            
            var quoteStatuses = await _quoteStatusService.GetAllAsync();
            var insurers = await _insurerService.GetAllAsync();

            resource.ClientId = result.ClientId;
            resource.PortfolioId = result.PortfolioId;
            resource.QuoteStatusList = SelectLists.QuoteStatuses(quoteStatuses, resource.QuoteStatusId);
            resource.InsurerList = SelectLists.Insurers(insurers, resource.InsurerId);

            return View(resource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, QuoteResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _quoteService.UpdateAsync(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction(nameof(Details), new { id = resource.Id });
            }

            var quoteStatuses = await _quoteStatusService.GetAllAsync();
            var insurers = await _insurerService.GetAllAsync();

            resource.QuoteStatusList = SelectLists.QuoteStatuses(quoteStatuses, resource.QuoteStatusId);
            resource.InsurerList = SelectLists.Insurers(insurers, resource.InsurerId);
            return View(resource);
        }

        // GET: Quotes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _quoteService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var resource = await _quoteService.GetByIdAsync((Guid)id);
            await _quoteService.DeleteAsync(resource);

            return RedirectToAction(nameof(Details), "PortfolioClients", new { resource.PortfolioClientId });
        }
    }
}
