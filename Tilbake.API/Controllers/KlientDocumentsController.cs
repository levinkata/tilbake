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
    public class KlientDocumentsController : ControllerBase
    {
        private readonly IKlientDocumentService _klientDocumentService;

        public KlientDocumentsController(IKlientDocumentService klientDocumentService)
        {
            _klientDocumentService = klientDocumentService ?? throw new ArgumentNullException(nameof(klientDocumentService));
        }

        // GET: api/KlientDocuments
        [HttpGet]
        public async Task<ActionResult> GetKlientDocuments(Guid klientId)
        {
            KlientDocumentsViewModel model = await _klientDocumentService.GetAllAsync(klientId).ConfigureAwait(true);
            return await Task.Run(() => Ok(model.KlientDocuments)).ConfigureAwait(true);
        }

        // GET: api/KlientDocuments/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetKlientDocument(Guid id)
        {
            KlientDocumentViewModel model = await _klientDocumentService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.KlientDocument)).ConfigureAwait(true);
        }

        // PUT: api/KlientDocuments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKlientDocument(Guid id, KlientDocument klientDocument)
        {
            if (klientDocument == null)
            {
                throw new ArgumentNullException(nameof(klientDocument));
            }

            if (id != klientDocument.ID)
            {
                return BadRequest();
            }

            KlientDocumentViewModel model = new KlientDocumentViewModel()
            {
                KlientDocument = klientDocument
            };

            await _klientDocumentService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/KlientDocuments
        [HttpPost]
        public async Task<ActionResult> PostKlientDocument(KlientDocument klientDocument)
        {
            KlientDocumentViewModel model = new KlientDocumentViewModel()
            {
                KlientDocument = klientDocument
            };

            await _klientDocumentService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/KlientDocuments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKlientDocument(Guid id)
        {
            KlientDocumentViewModel model = await _klientDocumentService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _klientDocumentService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
