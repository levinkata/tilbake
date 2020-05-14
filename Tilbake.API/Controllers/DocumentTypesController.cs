using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Models;

namespace Tilbake.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypesController : ControllerBase
    {
        private readonly IDocumentTypeService _documentTypeService;

        public DocumentTypesController(IDocumentTypeService documentTypeService)
        {
            _documentTypeService = documentTypeService ?? throw new ArgumentNullException(nameof(documentTypeService));
        }

        // GET: api/DocumentTypes
        [HttpGet]
        public async Task<ActionResult> GetDocumentTypes()
        {
            DocumentTypesViewModel model = await _documentTypeService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.DocumentTypes)).ConfigureAwait(true);
        }

        // GET: api/DocumentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDocumentType(Guid id)
        {
            DocumentTypeViewModel model = await _documentTypeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.DocumentType)).ConfigureAwait(true);
        }

        // PUT: api/DocumentTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentType(Guid id, DocumentType documentType)
        {
            if (documentType == null)
            {
                throw new ArgumentNullException(nameof(documentType));
            }

            if (id != documentType.ID)
            {
                return BadRequest();
            }

            DocumentTypeViewModel model = new DocumentTypeViewModel()
            {
                DocumentType = documentType
            };

            await _documentTypeService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/DocumentTypes
        [HttpPost]
        public async Task<ActionResult> PostDocumentType(DocumentType documentType)
        {
            DocumentTypeViewModel model = new DocumentTypeViewModel()
            {
                DocumentType = documentType
            };

            await _documentTypeService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/DocumentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentType(Guid id)
        {
            DocumentTypeViewModel model = await _documentTypeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _documentTypeService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
