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
        void Add(PaymentTypeSaveResource resource);
        void Update(PaymentTypeResource resource);
        void Delete(Guid id);
    }
}
