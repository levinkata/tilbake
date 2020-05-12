﻿using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IKlientDocumentService
    {
        Task<KlientDocumentsViewModel> GetAllAsync(Guid klientId);
        Task<KlientDocumentViewModel> GetAsync(Guid id);
        Task<int> AddAsync(KlientDocumentViewModel model);
        Task<int> UpdateAsync(KlientDocumentViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}