using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface ICarrierRepository
    {
        Task<IEnumerable<Carrier>> GetAllAsync();
        Task<Carrier> GetByIdAsync(Guid id);
        Task<Carrier> AddAsync(Carrier Carrier);
        Task <IEnumerable<Carrier>> AddRangeAsync (IEnumerable<Carrier> Carriers);
        Task<Carrier> UpdateAsync(Carrier Carrier);
        Task<Carrier> DeleteAsync(Guid id);
        Task<Carrier> DeleteAsync(Carrier Carrier);
        Task<IEnumerable<Carrier>> DeleteRangeAsync(IEnumerable<Carrier> Carriers);  
    }    
}