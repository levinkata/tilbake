using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface ICityRepository : IRepository<City>
    {
        Task<IEnumerable<City>> GetByCountryId(Guid countryId);
    }    
}