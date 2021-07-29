using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IAuditService
    {
        Task<IEnumerable<AuditResource>> GetAllAsync();
        Task<AuditResource> GetByIdAsync(Guid id);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(AuditResource resource);
    }
}