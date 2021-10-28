using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IRiskService
    {
        Task<IEnumerable<RiskResource>> GetAllAsync();
        Task<RiskResource> GetByIdAsync(Guid id);
        void Add(RiskSaveResource resource);
        void Update(RiskResource resource);
        void Delete(Guid id);
    }
}