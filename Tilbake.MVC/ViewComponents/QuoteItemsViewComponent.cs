using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;

namespace Tilbake.MVC.ViewComponents
{
    [Authorize]
    public class QuoteItemsViewComponent : ViewComponent
    {
        private readonly IQuoteItemService _quoteItemService;
        private readonly ITaxService _taxService;

        public QuoteItemsViewComponent(IQuoteItemService quoteItemService,
                                        ITaxService taxService)
        {
            _quoteItemService = quoteItemService;
            _taxService = taxService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid quoteId)
        {
            var taxes = await _taxService.GetAllAsync();
            var taxRate = taxes.Select(r => r.TaxRate).FirstOrDefault();

            ViewBag.TaxRate = taxRate;
            var resources = await _quoteItemService.GetByQuoteIdAsync(quoteId);
            
            return View(resources);
        }
    }
}
