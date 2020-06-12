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
    public class DocumentCategoriesController : ControllerBase
    {
        private readonly IDocumentCategoryService _documentCategoryService;

        public DocumentCategoriesController(IDocumentCategoryService documentCategoryService)
        {
            _documentCategoryService = documentCategoryService ?? throw new ArgumentNullException(nameof(documentCategoryService));
        }

        // GET: api/DocumentCategories
        [HttpGet]
        public async Task<IActionResult> GetDocumentCategories()
        {
            DocumentCategoriesViewModel model = await _documentCategoryService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.DocumentCategories)).ConfigureAwait(true);
        }

        // GET: api/DocumentCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentCategory(Guid id)
        {
            DocumentCategoryViewModel model = await _documentCategoryService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.DocumentCategory)).ConfigureAwait(true);
        }

        // PUT: api/DocumentCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentCategory(Guid id, DocumentCategory documentCategory)
        {
            if (documentCategory == null)
            {
                throw new ArgumentNullException(nameof(documentCategory));
            }

            if (id != documentCategory.ID)
            {
                return BadRequest();
            }

            DocumentCategoryViewModel model = new DocumentCategoryViewModel()
            {
                DocumentCategory = documentCategory
            };

            await _documentCategoryService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/DocumentCategories
        [HttpPost]
        public async Task<IActionResult> PostDocumentCategory(DocumentCategory documentCategory)
        {
            DocumentCategoryViewModel model = new DocumentCategoryViewModel()
            {
                DocumentCategory = documentCategory
            };

            await _documentCategoryService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/DocumentCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentCategory(Guid id)
        {
            DocumentCategoryViewModel model = await _documentCategoryService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _documentCategoryService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
