using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IClientCarrierRepository : IRepository<ClientCarrier>
    {
        Task<IEnumerable<ClientCarrier>> GetByClientId(Guid clientId);
    }
}