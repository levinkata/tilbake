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
        Task<int> AddAsync(InsurerBranchSaveResource resource);
        Task<int> UpdateAsync(InsurerBranchResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}