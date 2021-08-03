﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    public class ReceivablesController : Controller
    {
        private readonly IReceivableService _receivableService;
        private readonly IPaymentTypeService _paymentTypeService;

        public ReceivablesController(IReceivableService receivableService,
                                    IPaymentTypeService paymentTypeService)
        {
            _receivableService = receivableService;
            _paymentTypeService = paymentTypeService;
        }

        public async Task<IActionResult> Index(Guid invoiceId)
        {
            var resources = await _receivableService.GetByInvoiceIdAsync(invoiceId);
            ViewBag.InvoiceId = invoiceId;
            return View(resources);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid invoiceId)
        {
            var paymentTypes = await _paymentTypeService.GetAllAsync();

            ReceivableSaveResource resource = new()
            {
                InvoiceId = invoiceId,
                PaymentTypeList = SelectLists.PaymentTypes(paymentTypes, Guid.Empty)
            };

            return View(resource);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReceivableSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _receivableService.AddAsync(resource);
                return RedirectToAction(nameof(Index), new { resource.InvoiceId });
            }

            var paymentTypes = await _paymentTypeService.GetAllAsync();
            resource.PaymentTypeList = SelectLists.PaymentTypes(paymentTypes, resource.PaymentTypeId);

            return View(resource);
        }
    }
}