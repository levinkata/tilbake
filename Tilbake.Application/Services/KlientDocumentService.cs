using System;
using System.IO;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Services
{
    public class KlientDocumentService : IKlientDocumentService
    {
        private readonly IKlientDocumentRepository _klientDocumentRepository;

        public KlientDocumentService(IKlientDocumentRepository klientDocumentRepository)
        {
            _klientDocumentRepository = klientDocumentRepository;
        }

        public async Task<int> AddAsync(FileUpLoadViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            //  To change the file name if storing on disk and avoid malicious file names being loaded
            //  var fileName = Guid.NewGuid().ToString() + Path.GetExtension(document.FileName);

            KlientDocument klientDocument = new KlientDocument()
            {
                KlientID = model.KlientID,
                Description = Guid.NewGuid().ToString(),
                DocumentDate = DateTime.Now,
                DocumentCategoryID = model.DocumentCategoryID
            };

            using var memoryStream = new MemoryStream();
            await model.File.CopyToAsync(memoryStream).ConfigureAwait(true);
            klientDocument.Photo = memoryStream.ToArray();

            return await Task.Run(() => _klientDocumentRepository.AddAsync(klientDocument)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _klientDocumentRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<KlientDocumentsViewModel> GetAllAsync()
        {
            return new KlientDocumentsViewModel()
            {
                KlientDocuments = await Task.Run(() => _klientDocumentRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<KlientDocumentViewModel> GetAsync(Guid id)
        {
            //var hh = await _klientDocumentRepository.GetAsync(id).ConfigureAwait(true);
            //byte[] ll = hh.Document.ToArray();
            //using var memoryStream = new MemoryStream();
            //memoryStream.Write(ll, 0, (int)ll.Length);
            //File.WriteAllBytes(@"D:\source\repos\testpdf.pdf", memoryStream.ToArray());

            return new KlientDocumentViewModel()
            {
                KlientDocument = await Task.Run(() => _klientDocumentRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<KlientDocumentsViewModel> GetByKlientAsync(Guid klientId)
        {
            return new KlientDocumentsViewModel()
            {
                KlientDocuments = await Task.Run(() => _klientDocumentRepository.GetByKlientAsync(klientId)).ConfigureAwait(true),
                KlientID = klientId
            };
        }

        public async Task<int> UpdateAsync(KlientDocumentViewModel model)
        {
            return await Task.Run(() => _klientDocumentRepository.UpdateAsync(model.KlientDocument)).ConfigureAwait(true);
        }
    }
}
