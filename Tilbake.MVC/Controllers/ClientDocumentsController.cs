using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Helpers;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    [Authorize]
    public class ClientDocumentsController : BaseController
    {
        public ClientDocumentsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: ClientDocuments
        public IActionResult Index(Guid clientId)
        {
            ViewBag.ClientId = clientId;
            return View();
        }

        // GET: ClientDocuments/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _unitOfWork.ClientDocuments.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<ClientDocument, ClientDocumentViewModel>(result);
            return View(model);
        }

        // GET: ClientDocuments/Create
        public async Task<IActionResult> Create(Guid portfolioId, Guid clientId)
        {
            var documentTypes = await _unitOfWork.DocumentTypes.GetAll(r => r.OrderBy(n => n.Name));

            ClientDocumentViewModel ViewModel = new()
            {
                ClientId = clientId,
                PortfolioId = portfolioId,
                DocumentTypeList = MVCHelperExtensions.ToSelectList(documentTypes, Guid.Empty),
            };

            return View(ViewModel);
        }

        // POST: ClientDocuments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientDocumentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var file = model.File;

                var basePath = Path.Combine(Directory.GetCurrentDirectory() + Constants.ClientFolder);
                bool basePathExists = Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);

                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var filePath = Path.Combine(basePath, file.FileName);
                var extension = Path.GetExtension(file.FileName);

                if (!File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var clientDocument = _mapper.Map<ClientDocumentViewModel, ClientDocument>(model);
                    clientDocument.Id = Guid.NewGuid();
                    clientDocument.FileType = file.ContentType;
                    clientDocument.Extension = extension;
                    clientDocument.Name = fileName;
                    clientDocument.DocumentDate = DateTime.Now;
                    clientDocument.DocumentPath = filePath;
                    clientDocument.DateAdded = DateTime.Now;

                    await _unitOfWork.ClientDocuments.AddAsync(clientDocument);
                }
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Details), "PortfolioClients", new { model.PortfolioId, model.ClientId });
            }
            var documentTypes = await _unitOfWork.DocumentTypes.GetAll(r => r.OrderBy(n => n.Name));

            model.DocumentTypeList = MVCHelperExtensions.ToSelectList(documentTypes, model.DocumentTypeId);
            return View(model);
        }

        // GET: ClientDocuments/DownloadFile/5
        public async Task<IActionResult> DownloadFile(Guid id)
        {
            var result = await _unitOfWork.ClientDocuments.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(result.DocumentPath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, result.FileType, result.Name + result.Extension);
        }

        // GET: ClientDocuments/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.ClientDocuments.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<ClientDocument, ClientDocumentViewModel>(result);
            return View(model);
        }

        // POST: ClientDocuments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, ClientDocumentViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var clientDocument = _mapper.Map<ClientDocumentViewModel, ClientDocument>(model);
                clientDocument.DateModified = DateTime.Now;

                await _unitOfWork.ClientDocuments.Update(clientDocument);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: ClientDocuments/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.ClientDocuments.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<ClientDocument, ClientDocumentViewModel>(result);
            return View(model);
        }

        // POST: ClientDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(ClientDocumentViewModel model)
        {
            _unitOfWork.ClientDocuments.Delete(model.Id);
            return RedirectToAction(nameof(Details), "PortfolioClients", new { model.ClientId });
        }
    }
}
