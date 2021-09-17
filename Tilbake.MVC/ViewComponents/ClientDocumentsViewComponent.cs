using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;

namespace Tilbake.MVC.ViewComponents
{
    public class ClientDocumentsViewComponent : ViewComponent
    {
        private readonly IClientDocumentService _clientDocumentService;

        public ClientDocumentsViewComponent(IClientDocumentService clientDocumentService)
        {
            _clientDocumentService = clientDocumentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid portfolioId, Guid clientId)
        {
            ViewBag.PortfolioId = portfolioId;
            ViewBag.ClientId = clientId;
            return View(await _clientDocumentService.GetByClientIdAsync(clientId));
        }
    }
}
