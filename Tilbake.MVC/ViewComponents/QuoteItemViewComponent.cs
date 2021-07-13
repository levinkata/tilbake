using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;

namespace Tilbake.MVC.ViewComponents
{
    [Authorize]
    public class QuoteItemViewComponent : ViewComponent
    {
        private readonly IInsurerService _insurerService;
        private readonly ICoverTypeService _coverTypeService;
        private readonly IQuoteStatusService _quoteStatusService;

        public QuoteItemViewComponent(IInsurerService insurerService,
                                    ICoverTypeService coverTypeService,
                                    IQuoteStatusService quoteStatusService)
        {
            _insurerService = insurerService;
            _coverTypeService = coverTypeService;
            _quoteStatusService = quoteStatusService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid portfolioClientId, [FromBody] List<QuoteItem> paramObjects)
        {
            //  var insurers = await _insurerService.GetAllAsync();
            var coverTypes = await _coverTypeService.GetAllAsync();
            var quoteStatuses = await _quoteStatusService.GetAllAsync();

            QuoteResource resource = new QuoteResource()
            {
                PortfolioClientId = portfolioClientId,
                //  InsurerList = new SelectList(insurers, "Id", "Name"),
                CoverageList = new SelectList(coverTypes, "Id", "Name"),
                QuoteStatusList = new SelectList(quoteStatuses, "Id", "Name")
            };
            resource.QuoteItems.AddRange(paramObjects);

            return await Task.Run(() => View(resource)).ConfigureAwait(true);
        }
    }
}
