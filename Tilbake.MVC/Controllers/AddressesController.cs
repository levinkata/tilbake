using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    public class AddressesController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var resource = await _addressService.GetByIdAsync(id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        [HttpGet]
        public async Task<IActionResult> GetByClientId(Guid clientId)
        {
            var resource = await _addressService.GetByClientIdAsync(clientId);

            return Ok(new { resource });
        }

        [HttpPut]
        public async Task<IActionResult> PutAddress(AddressResource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            };

            var result = await _addressService.UpdateAsync(resource);

            return Ok(new { result });
        }

        [HttpPost]
        public async Task<IActionResult> PostAddress(AddressSaveResource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            };

            var result = await _addressService.AddAsync(resource);

            return Ok(new { result });
        }
    }
}
