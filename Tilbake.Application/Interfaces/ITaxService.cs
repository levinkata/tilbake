using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface ITaxService
    {
        Task<IEnumerable<TaxResource>> GetAllAsync();
        Task<TaxResource> GetByIdAsync(Guid id);
        void Add(TaxSaveResource resource);
        void Update(TaxResource resource);
        void Delete(Guid id);
    }
}