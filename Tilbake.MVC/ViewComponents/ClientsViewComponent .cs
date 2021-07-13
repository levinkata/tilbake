using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;

namespace Tilbake.MVC.ViewComponents
{
    public class ClientsViewComponent : ViewComponent
    {
        private readonly IClientService _clientService;
        private readonly IPortfolioClientService _portfolioClientService;

        public ClientsViewComponent(IClientService clientService,
                                IPortfolioClientService portfolioClientService)
        {
            _clientService = clientService;
            _portfolioClientService = portfolioClientService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? portfolioId)
        {
            ViewBag.PortfolioId = portfolioId;

            if (portfolioId == Guid.Empty)
            {
                return View(await Task.Run(() => _clientService.GetAllAsync()).ConfigureAwait(true));
            }
            else
            {
                return View(await Task.Run(() => _portfolioClientService.GetByPortfoloId((Guid)portfolioId)).ConfigureAwait(true));

            }
        }
    }
}
