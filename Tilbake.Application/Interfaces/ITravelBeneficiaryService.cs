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
        void Add(TravelBeneficiarySaveResource resource);
        void Update(TravelBeneficiaryResource resource);
        void Delete(Guid id);
    }
}