using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

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
            var resources = await _clientCarrierService.GetByClientIdAsync(clientId);
            return View(resources);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid portfolioId, Guid clientId)
        {
            var carriers = await _carrierService.GetAllAsync();

            ClientCarrierSaveResource resource = new()
            {
                PortfolioId = portfolioId,
                ClientId = clientId
            };
            resource.CarrierList = SelectLists.Carriers(carriers, resource.CarrierIds);

            return View(resource);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientCarrierSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _clientCarrierService.AddAsync(resource);
                return RedirectToAction("Details", "PortfolioClients", new { portfolioId = resource.PortfolioId, clientId = resource.ClientId });
            }

            return View(resource);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid portfolioId, Guid clientId)
        {
            var carriers = await _carrierService.GetAllAsync();
            var clientCarriers = await _clientCarrierService.GetByClientIdAsync(clientId);
            var selectedCarrierIds = clientCarriers.Select(r => r.CarrierId).ToArray();

            ClientCarrierSaveResource resource = new()
            {
                PortfolioId = portfolioId,
                ClientId = clientId
            };
            if(selectedCarrierIds != null)
            {
                resource.CarrierIds = selectedCarrierIds;
            }

            resource.CarrierList = SelectLists.Carriers(carriers, resource.CarrierIds);

            return View(resource);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ClientCarrierResource resource)
        {
            await _clientCarrierService.UpdateAsync(resource);
            return RedirectToAction("Details", "PortfolioClients", new { portfolioId = resource.PortfolioId, clientId = resource.ClientId });
        }
    }
}
