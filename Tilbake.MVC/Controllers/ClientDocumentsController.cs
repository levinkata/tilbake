using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

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

            var resource = await _clientDocumentService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // GET: ClientDocuments/Create
        public async Task<IActionResult> Create(Guid portfolioId, Guid clientId)
        {
            var documentTypes = await _documentTypeService.GetAllAsync();

            ClientDocumentSaveResource resource = new()
            {
                ClientId = clientId,
                PortfolioId = portfolioId,
                DocumentTypeList = SelectLists.DocumentTypes(documentTypes, Guid.Empty),
            };

            return View(resource);
        }

        // POST: ClientDocuments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientDocumentSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _clientDocumentService.AddAsync(resource);
                return RedirectToAction(nameof(Details), "PortfolioClients", new { resource.PortfolioId, resource.ClientId });
            }
            var documentTypes = await _documentTypeService.GetAllAsync();

            resource.DocumentTypeList = SelectLists.DocumentTypes(documentTypes, resource.DocumentTypeId);
            return View(resource);
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

            var resource = await _clientDocumentService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }
            return View(resource);
        }

        // POST: ClientDocuments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid? id, ClientDocumentResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _clientDocumentService.UpdateAsync(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: ClientDocuments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _clientDocumentService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: ClientDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(ClientDocumentResource resource)
        {
            _clientDocumentService.DeleteAsync(resource.Id);
            return RedirectToAction(nameof(Details), "PortfolioClients", new { resource.ClientId });
        }
    }
}
