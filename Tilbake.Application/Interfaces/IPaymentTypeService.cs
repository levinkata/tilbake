using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IPaymentTypeService
    {
        Task<IEnumerable<PaymentTypeResource>> GetAllAsync();
        Task<PaymentTypeResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(PaymentTypeSaveResource resource);
        Task<int> UpdateAsync(PaymentTypeResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(PaymentTypeResource resource);
    }
}
