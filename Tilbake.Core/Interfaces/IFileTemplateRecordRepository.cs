using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IFileTemplateRecordRepository : IRepository<FileTemplateRecord>
    {
        Task<IEnumerable<FileTemplateRecord>> GetByFileTemplateId(Guid fileTemplateId);
        Task<IEnumerable<FileTemplateRecord>> GetTableFileTemplate(Guid fileTemplateId, string tableName);
    }
}
