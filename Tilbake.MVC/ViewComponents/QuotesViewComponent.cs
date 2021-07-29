using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;

namespace Tilbake.MVC.ViewComponents
{
    public class QuotesViewComponent : ViewComponent
    {
        private readonly IQuoteService _quoteService;

        public QuotesViewComponent(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid portfolioClientId)
        {
            ViewBag.PortfolioClientId = portfolioClientId;
            return View(await Task.Run(() => _quoteService.GetByPortfolioClientAsync(portfolioClientId)));
        }
    }
}
