using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IFileTemplateRecordService
    {
        Task<IEnumerable<FileTemplateRecordResource>> GetAllAsync();
        Task<IEnumerable<FileTemplateRecordResource>> GetByFileTemplateIdAsync(Guid fileTemplateId);
        Task<FileTemplateRecordResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(FileTemplateRecordSaveResource resource);
        Task<int> UpdateAsync(FileTemplateRecordResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(FileTemplateRecordResource resource);
    }
}
