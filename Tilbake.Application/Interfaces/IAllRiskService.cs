using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IAllRiskService
    {
        Task<IEnumerable<AllRiskResource>> GetAllAsync();
        Task<AllRiskResource> GetByIdAsync(Guid id);
        void Add(AllRiskSaveResource resource);
        void Update(AllRiskResource resource);
        void Delete(Guid id);
    }
}
