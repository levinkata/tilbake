using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface ICityRepository : IRepository<City>
    {
        Task<IEnumerable<City>> GetByCountryId(Guid countryId);
    }    
}