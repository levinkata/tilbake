using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IPaymentMethodService
    {
        Task<IEnumerable<PaymentMethodResource>> GetAllAsync();
        Task<PaymentMethodResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(PaymentMethodSaveResource resource);
        Task<int> UpdateAsync(PaymentMethodResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(PaymentMethodResource resource);
    }
}
