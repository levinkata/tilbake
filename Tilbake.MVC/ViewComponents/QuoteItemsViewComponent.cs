using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;

namespace Tilbake.MVC.ViewComponents
{
    [Authorize]
    public class QuoteItemsViewComponent : ViewComponent
    {
        private readonly IQuoteItemService _quoteItemService;

        public QuoteItemsViewComponent(IQuoteItemService quoteItemService)
        {
            _quoteItemService = quoteItemService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid quoteId)
        {
            var resources = await _quoteItemService.GetByQuoteIdAsync(quoteId);
            return await Task.Run(() => View(resources));
        }
    }
}
