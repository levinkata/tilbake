using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    [Authorize]
    public class ClientDocumentsController : Controller
    {
        private readonly IClientDocumentService _clientDocumentService;
        private readonly IDocumentTypeService _documentTypeService;

        public ClientDocumentsController(IClientDocumentService clientDocumentService,
            IDocumentTypeService documentTypeService)
        {
            _clientDocumentService = clientDocumentService;
            _documentTypeService = documentTypeService;
        }

        // GET: ClientDocuments
        public async Task<IActionResult> Index(Guid clientId)
        {
            ViewBag.ClientId = clientId;
            return await Task.Run(() => View());
        }

        // GET: ClientDocuments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _clientDocumentService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // GET: ClientDocuments/Create
        public async Task<IActionResult> Create(Guid portfolioId, Guid clientId)
        {
            var documentTypes = await _documentTypeService.GetAllAsync();

            ClientDocumentViewModel ViewModel = new()
            {
                ClientId = clientId,
                PortfolioId = portfolioId,
                DocumentTypeList = SelectLists.DocumentTypes(documentTypes, Guid.Empty),
            };

            return View(ViewModel);
        }

        // POST: ClientDocuments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientDocumentViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                await _clientDocumentService.AddAsync(ViewModel);
                return RedirectToAction(nameof(Details), "PortfolioClients", new { ViewModel.PortfolioId, ViewModel.ClientId });
            }
            var documentTypes = await _documentTypeService.GetAllAsync();

            ViewModel.DocumentTypeList = SelectLists.DocumentTypes(documentTypes, ViewModel.DocumentTypeId);
            return View(ViewModel);
        }

        // GET: ClientDocuments/DownloadFile/5
        public async Task<IActionResult> DownloadFile(Guid id)
        {

            var result = await _clientDocumentService.GetByIdAsync(id);
            if (result == null) return null;

            var memory = new MemoryStream();
            using (var stream = new FileStream(result.DocumentPath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, result.FileType, result.Name + result.Extension);
        }

        // GET: ClientDocuments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _clientDocumentService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            return View(ViewModel);
        }

        // POST: ClientDocuments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid? id, ClientDocumentViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _clientDocumentService.UpdateAsync(ViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ViewModel);
        }

        // GET: ClientDocuments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _clientDocumentService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // POST: ClientDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(ClientDocumentViewModel ViewModel)
        {
            _clientDocumentService.DeleteAsync(ViewModel.Id);
            return RedirectToAction(nameof(Details), "PortfolioClients", new { ViewModel.ClientId });
        }
    }
}
