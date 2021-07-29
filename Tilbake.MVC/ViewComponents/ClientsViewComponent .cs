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

        public ClientsViewComponent(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? portfolioId)
        {
            ViewBag.PortfolioId = portfolioId;

            if (portfolioId == Guid.Empty)
            {
                return View(await Task.Run(() => _clientService.GetAllAsync()));
            }
            else
            {
                return View(await Task.Run(() => _clientService.GetByPortfoloId((Guid)portfolioId)));

            }
        }
    }
}
