using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IApplicationSessionRepository : IRepository<ApplicationSession>
    {
        Task<IEnumerable<ApplicationSession>> GetByUserId(string userId);
        Task DeleteByUserId(string userId);
    }    
}