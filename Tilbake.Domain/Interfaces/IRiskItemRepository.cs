using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IRiskItemRepository
    {
        Task<IEnumerable<RiskItem>> GetAllAsync();
        Task<RiskItem> GetAsync(Guid id);
        Task<int> AddAsync(RiskItem riskItem);
        Task<int> UpdateAsync(RiskItem riskItem);
        Task<int> DeleteAsync(Guid id);
    }
}
