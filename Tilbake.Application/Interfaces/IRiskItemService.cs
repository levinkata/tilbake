using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IRiskItemService
    {
        Task<IEnumerable<RiskItemResource>> GetAllAsync();
        Task<RiskItemResource> GetByIdAsync(Guid id);
        void Add(RiskItemSaveResource resource);
        void Update(RiskItemResource resource);
        void Delete(Guid id);
    }
}
