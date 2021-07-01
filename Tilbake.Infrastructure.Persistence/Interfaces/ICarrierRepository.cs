using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface ICarrierRepository
    {
        Task<IQueryable<Carrier>> GetAllAsync();
        Task<Carrier> GetByIdAsync(Guid id);
        Task<Carrier> AddAsync(Carrier Carrier);
        Task <IQueryable<Carrier>> AddRangeAsync (IQueryable<Carrier> Carriers);
        Task<Carrier> UpdateAsync(Carrier Carrier);
        Task<Carrier> DeleteAsync(Guid id);
        Task<Carrier> DeleteAsync(Carrier Carrier);
        Task<IQueryable<Carrier>> DeleteRangeAsync(IQueryable<Carrier> Carriers);  
    }    
}