using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class ClientCarriersController : Controller
    {
        private readonly IClientCarrierService _clientCarrierService;
        private readonly ICarrierService _carrierService;

        public ClientCarriersController(IClientCarrierService clientCarrierService,
                                        ICarrierService carrierService)
        {
            _clientCarrierService = clientCarrierService;
            _carrierService = carrierService;
        }

        public async Task<IActionResult> Index(Guid clientId)
        {
            var ViewModels = await _clientCarrierService.GetByClientIdAsync(clientId);
            return View(ViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid portfolioId, Guid clientId)
        {
            var carriers = await _carrierService.GetAllAsync();

            ClientCarrierViewModel ViewModel = new()
            {
                PortfolioId = portfolioId,
                ClientId = clientId
            };
            ViewModel.CarrierList = SelectLists.Carriers(carriers, ViewModel.CarrierIds);

            return View(ViewModel);
        }

        [HttpPost]
        public IActionResult Create(ClientCarrierViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                _clientCarrierService.AddAsync(ViewModel);
                return RedirectToAction("Details", "PortfolioClients", new { portfolioId = ViewModel.PortfolioId, clientId = ViewModel.ClientId });
            }

            return View(ViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid portfolioId, Guid clientId)
        {
            var carriers = await _carrierService.GetAllAsync();
            var clientCarriers = await _clientCarrierService.GetByClientIdAsync(clientId);
            var selectedCarrierIds = clientCarriers.Select(r => r.CarrierId).ToList();

            ClientCarrierViewModel ViewModel = new()
            {
                PortfolioId = portfolioId,
                ClientId = clientId
            };
            if(selectedCarrierIds != null)
            {
                ViewModel.CarrierIds = selectedCarrierIds;
            }

            ViewModel.CarrierList = SelectLists.Carriers(carriers, ViewModel.CarrierIds);

            return View(ViewModel);
        }

        [HttpPost]
        public IActionResult Update(ClientCarrierViewModel ViewModel)
        {
            _clientCarrierService.UpdateAsync(ViewModel);
            return RedirectToAction("Details", "PortfolioClients", new { portfolioId = ViewModel.PortfolioId, clientId = ViewModel.ClientId });
        }
    }
}
