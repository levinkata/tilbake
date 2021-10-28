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
        void Add(PaymentMethodSaveResource resource);
        void Update(PaymentMethodResource resource);
        void Delete(Guid id);
    }
}
