using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IInsurerBranchService
    {
        Task<IEnumerable<InsurerBranchResource>> GetAllAsync();
        Task<IEnumerable<InsurerBranchResource>> GetByInsurerIdAsync(Guid insurerId);
        Task<InsurerBranchResource> GetByIdAsync(Guid id);
        Task<InsurerBranchResource> GetByNameAsync(string name);
        void Add(InsurerBranchSaveResource resource);
        void Update(InsurerBranchResource resource);
        void Delete(Guid id);
    }
}