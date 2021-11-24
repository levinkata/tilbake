using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IInsurerBranchRepository : IRepository<InsurerBranch>
    {
        Task<IEnumerable<InsurerBranch>> GetByInsurerId(Guid insurerId);
        Task<InsurerBranch> GetByName(string name);
    }    
}