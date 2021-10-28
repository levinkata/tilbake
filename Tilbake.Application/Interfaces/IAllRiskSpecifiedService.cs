using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IAllRiskSpecifiedService
    {
        Task<IEnumerable<AllRiskSpecifiedResource>> GetAllAsync();
        Task<AllRiskSpecifiedResource> GetByIdAsync(Guid id);
        void Add(AllRiskSpecifiedSaveResource resource);
        void Update(AllRiskSpecifiedResource resource);
        void Delete(Guid id);
    }
}
