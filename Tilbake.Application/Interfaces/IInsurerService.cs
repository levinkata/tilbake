using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IInsurerService
    {
        Task<IEnumerable<InsurerResource>> GetAllAsync();
        Task<InsurerResource> GetByIdAsync(Guid id);
        void Add(InsurerSaveResource resource);
        void Update(InsurerResource resource);
        void Delete(Guid id);
    }
}