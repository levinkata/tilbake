using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IExcessBuyBackService
    {
        Task<IEnumerable<ExcessBuyBackResource>> GetAllAsync();
        Task<ExcessBuyBackResource> GetByIdAsync(Guid id);
        void Add(ExcessBuyBackSaveResource resource);
        void Update(ExcessBuyBackResource resource);
        void Delete(Guid id);
    }
}