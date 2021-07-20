using System;
using System.Linq.Expressions;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Projections
{
    public class CountryProjection
    {

        public static Expression<Func<Country, dynamic>> CountryWithCities
        {
            get
            {
                return x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Cities = x.Cities.Count
                };
            }
        }
    }
}
