using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;

namespace Tilbake.MVC.ViewComponents
{
    public class ClientCarriersViewComponent : ViewComponent
    {
        private readonly IClientCarrierService _clientCarrierService;

        public ClientCarriersViewComponent(IClientCarrierService clientCarrierService)
        {
            _clientCarrierService = clientCarrierService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid portfolioId, Guid clientId)
        {
            ViewBag.PortfolioId = portfolioId;
            ViewBag.ClientId = clientId;
            return View(await _clientCarrierService.GetByClientIdAsync(clientId));
        }
    }
}
