using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class KlientDocumentService : IKlientDocumentService
    {
        private readonly IKlientDocumentRepository _klientDocumentRepository;

        public KlientDocumentService(IKlientDocumentRepository klientDocumentRepository)
        {
            _klientDocumentRepository = klientDocumentRepository;
        }

        public async Task<int> AddAsync(KlientDocumentViewModel model)
        {
            return await Task.Run(() => _klientDocumentRepository.AddAsync(model.KlientID, model.KlientDocument, model.DocumentFiles)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _klientDocumentRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<KlientDocumentsViewModel> GetAllAsync(Guid klientId)
        {
            return new KlientDocumentsViewModel()
            {
                KlientDocuments = await Task.Run(() => _klientDocumentRepository.GetAllAsync(klientId)).ConfigureAwait(true),
                KlientID = klientId
            };
        }

        public async Task<KlientDocumentViewModel> GetAsync(Guid id)
        {
            return new KlientDocumentViewModel()
            {
                KlientDocument = await Task.Run(() => _klientDocumentRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(KlientDocumentViewModel model)
        {
            return await Task.Run(() => _klientDocumentRepository.UpdateAsync(model.KlientDocument)).ConfigureAwait(true);
        }
    }
}
