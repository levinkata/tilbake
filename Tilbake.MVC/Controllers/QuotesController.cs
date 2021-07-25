using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    [Authorize]
    public class QuotesController : Controller
    {
        private readonly IQuoteService _quoteService;
        private readonly ICoverTypeService _coverTypeService;
        private readonly IInsurerService _insurerService;
        private readonly IQuoteStatusService _quoteStatusService;
        private readonly IBodyTypeService _bodyTypeService;
        private readonly IDriverTypeService _driverTypeService;
        private readonly IMotorMakeService _motorMakeService;
        private readonly IMotorModelService _motorModelService;
        private readonly IMotorUseService _motorUseService;
        private readonly IPortfolioClientService _portfolioClientService;

        public QuotesController(IQuoteService quoteService,
                                ICoverTypeService coverTypeService,
                                IInsurerService insurerService,
                                IQuoteStatusService quoteStatusService,
                                IBodyTypeService bodyTypeService,
                                IDriverTypeService driverTypeService,
                                IMotorMakeService motorMakeService,
                                IMotorModelService motorModelService,
                                IMotorUseService motorUseService,
                                IPortfolioClientService portfolioClientService)
        {
            _quoteService = quoteService;
            _coverTypeService = coverTypeService;
            _insurerService = insurerService;
            _quoteStatusService = quoteStatusService;
            _bodyTypeService = bodyTypeService;
            _driverTypeService = driverTypeService;
            _motorMakeService = motorMakeService;
            _motorModelService = motorModelService;
            _motorUseService = motorUseService;
            _portfolioClientService = portfolioClientService;
        }

        // GET: Quotes
        public async Task<IActionResult> Index(Guid portfolioId)
        {
            var resources = await _quoteService.GetByPortfolioAsync(portfolioId).ConfigureAwait(true);
            return await Task.Run(() => View(resources)).ConfigureAwait(true);
        }

        public async Task<IActionResult> Quotation()
        {
            return await Task.Run(() => View()).ConfigureAwait(true);
        }

        // GET: Quotes/Details/5
        public async Task<IActionResult> Details(Guid? id)
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
        
        [HttpPost]
        public async Task<IActionResult> PostQuote(QuoteObjectResource quoteObject)
        {
            if (quoteObject.QuoteItems == null)
            {
                throw new ArgumentNullException(nameof(quoteObject.QuoteItems));
            };

            var portfolioClientId = quoteObject.Quote.PortfolioClientId;

            await _quoteService.AddAsync(quoteObject).ConfigureAwait(true);

            return await Task.Run(() => Ok(new
            {
                quoteObject.Quote.Id,
                quoteObject.Quote.PortfolioClientId,
                quoteObject.Quote.QuoteNumber
            })).ConfigureAwait(true);
        }

        // GET: Quotes/Create
        public async Task<IActionResult> Create(Guid portfolioClientId)
        {
            var portfolioClient = await _portfolioClientService.FindAsync(portfolioClientId);
            var clientId = portfolioClient.ClientId;

            var bodyTypes = await _bodyTypeService.GetAllAsync();
            var driverTypes = await _driverTypeService.GetAllAsync();
            var motorMakes = await _motorMakeService.GetAllAsync();
            var motorMakeId = motorMakes.FirstOrDefault().Id;
            var motorModels = await _motorModelService.GetByMotorMakeIdAsync(motorMakeId);
            var motorUses = await _motorUseService.GetAllAsync();
            
            var coverTypes = await _coverTypeService.GetAllAsync();
            var quoteStatuses = await _quoteStatusService.GetAllAsync();

            QuoteSaveResource resource = new QuoteSaveResource()
            {
                PortfolioClientId = portfolioClientId,
                ClientId = clientId,
                CoverTypelList = new SelectList(coverTypes, "Id", "Name"),
                QuoteStatusList = new SelectList(quoteStatuses, "Id", "Name"),
                BodyTypeList = new SelectList(bodyTypes, "Id", "Name"),
                DriverTypeList = new SelectList(driverTypes, "Id", "Name"),
                MotorMakeList = new SelectList(motorMakes, "Id", "Name"),
                MotorModelList = new SelectList(motorModels, "Id", "Name"),
                MotorUseList = new SelectList(motorUses, "Id", "Name")
            };

            return await Task.Run(() => View(resource)).ConfigureAwait(true);
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

            return await Task.Run(() => View(resource)).ConfigureAwait(true);
        }

        // GET: Quotes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
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
            
            var quoteStatuses = await _quoteStatusService.GetAllAsync();
            var insurers = await _insurerService.GetAllAsync();

            resource.QuoteStatusList = new SelectList(quoteStatuses, "Id", "Name");
            resource.InsurerList = new SelectList(insurers, "Id", "Name");

            return await Task.Run(() => View(resource)).ConfigureAwait(true);
        }

        // POST: Quotes/Edit/5
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
                return RedirectToAction(nameof(Details), "PortfolioClients", new { resource.PortfolioClientId });
            }
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
