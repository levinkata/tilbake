using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface ITitleService
    {
        Task<IEnumerable<TitleResource>> GetAllAsync();
        Task<TitleResource> GetByIdAsync(Guid id);
        void Add(TitleSaveResource resource);
        void Update(TitleResource resource);
        void Delete(Guid id);
    }
}