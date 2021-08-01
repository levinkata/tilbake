using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;

namespace Tilbake.MVC.ViewComponents
{
    public class ClientsViewComponent : ViewComponent
    {
        private readonly IClientService _clientService;

        public ClientsViewComponent(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? portfolioId)
        {
 
            if (portfolioId == Guid.Empty)
            {
                return View(await Task.Run(() => _clientService.GetAllAsync()));
            }
            else
            {
                ViewBag.PortfolioId = portfolioId;
                return View(await Task.Run(() => _clientService.GetByPortfoloId((Guid)portfolioId)));

            }
        }
    }
}
