using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IResidenceTypeRepository
    {
        Task<IEnumerable<ResidenceType>> GetAllAsync();
        Task<ResidenceType> GetAsync(Guid id);
        Task<int> AddAsync(ResidenceType residenceType);
        Task<int> UpdateAsync(ResidenceType residenceType);
        Task<int> DeleteAsync(Guid id);
    }
}