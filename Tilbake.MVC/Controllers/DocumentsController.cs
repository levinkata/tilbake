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
    public class DocumentsController : BaseController
    {
        public DocumentsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: Documents
        public IActionResult Index(Guid customerId)
        {
            ViewBag.CustomerId = customerId;
            return View();
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.Documents.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<Document, DocumentViewModel>(result);
            return View(model);
        }

        // GET: Documents/Create
        public async Task<IActionResult> Create(Guid portfolioId, Guid customerId)
        {
            var documentTypes = await _unitOfWork.DocumentTypes.GetAll(r => r.OrderBy(n => n.Name));

            DocumentViewModel model = new()
            {
                CustomerId = customerId,
                PortfolioId = portfolioId,
                DocumentTypeList = MVCHelperExtensions.ToSelectList(documentTypes, Guid.Empty),
            };

            return View(model);
        }

        // POST: Documents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var file = model.Document;

                var basePath = Path.Combine(Directory.GetCurrentDirectory() + Constants.CustomerFolder);
                bool basePathExists = Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);

                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var filePath = Path.Combine(basePath, file.FileName);
                var extension = Path.GetExtension(file.FileName);

                if (!System.IO.File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var customerDocument = _mapper.Map<DocumentViewModel, Document>(model);
                    customerDocument.Id = Guid.NewGuid();
                    customerDocument.FileType = file.ContentType;
                    customerDocument.Extension = extension;
                    customerDocument.Name = fileName;
                    customerDocument.DocumentDate = DateTime.Now;
                    customerDocument.DocumentPath = filePath;
                    customerDocument.DateAdded = DateTime.Now;

                    await _unitOfWork.Documents.AddAsync(customerDocument);
                }
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Details), "PortfolioCustomers", new { model.PortfolioId, model.CustomerId });
            }
            var documentTypes = await _unitOfWork.DocumentTypes.GetAll(r => r.OrderBy(n => n.Name));

            model.DocumentTypeList = MVCHelperExtensions.ToSelectList(documentTypes, model.DocumentTypeId);
            return View(model);
        }

        // GET: Documents/DownloadFile/5
        public async Task<IActionResult> DownloadFile(Guid id)
        {
            var result = await _unitOfWork.Documents.GetById(id);
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

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.Documents.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<Document, DocumentViewModel>(result);
            return View(model);
        }

        // POST: Documents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, DocumentViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var customerDocument = _mapper.Map<DocumentViewModel, Document>(model);
                customerDocument.DateModified = DateTime.Now;

                await _unitOfWork.Documents.Update(customerDocument);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.Documents.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<Document, DocumentViewModel>(result);
            return View(model);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(DocumentViewModel model)
        {
            _unitOfWork.Documents.Delete(model.Id);
            return RedirectToAction(nameof(Details), "PortfolioCustomers", new { model.CustomerId });
        }
    }
}
