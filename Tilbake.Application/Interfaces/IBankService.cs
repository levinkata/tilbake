using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IBankService
    {
        Task<IEnumerable<BankResource>> GetAllAsync();
        Task<BankResource> GetByIdAsync(Guid id);
        void Add(BankSaveResource resource);
        void Update(BankResource resource);
        void Delete(Guid id);
    }
}