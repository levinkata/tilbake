using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface ITravelBeneficiaryService
    {
        Task<IEnumerable<TravelBeneficiaryResource>> GetAllAsync();
        Task<TravelBeneficiaryResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(TravelBeneficiarySaveResource resource);
        Task<int> UpdateAsync(TravelBeneficiaryResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(TravelBeneficiaryResource resource);
    }
}