using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> GetByIdNumber(string idNumber);
    }
}