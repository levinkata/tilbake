using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    public class ClientCarriersController : Controller
    {
        private readonly IClientCarrierService _clientCarrierService;

        public ClientCarriersController(IClientCarrierService clientCarrierService)
        {
            _clientCarrierService = clientCarrierService;
        }

        public async Task<IActionResult> Index(Guid clientId)
        {
            var resources = await _clientCarrierService.GetByClientIdAsync(clientId);
            return View(resources);
        }

        [HttpGet]
        public IActionResult Create(Guid clientId)
        {
            ClientCarrierSaveResource resource = new()
            {
                ClientId = clientId
            };
            return View(resource);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientCarrierSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _clientCarrierService.AddAsync(resource);
                return RedirectToAction(nameof(Index), new { clientId = resource.ClientId });
            }

            return View(resource);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ClientCarrierResource resource)
        {
            await _clientCarrierService.UpdateAsync(resource);
            return RedirectToAction(nameof(Index), new { clientId = resource.ClientId });
        }
    }
}
