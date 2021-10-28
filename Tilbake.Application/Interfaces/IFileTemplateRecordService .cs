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
        Task<IEnumerable<FileTemplateRecordResource>> GetTableFileTemplate(Guid fileTemplateId, string tableName);
        Task<FileTemplateRecordResource> GetByIdAsync(Guid id);
        void Update(FileTemplateRecordResource resource);
        void Delete(Guid id);
    }
}
