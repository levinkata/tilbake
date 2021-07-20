using System;
using System.Linq.Expressions;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Projections
{
    public class PortfolioProjection
    {

        public static Expression<Func<Portfolio, dynamic>> PortfolioWithCities
        {
            get
            {
                return m => new
                {
                    m.Id,
                    m.Name,
                    NumberOfClients = m.PortfolioClients.Count
                };
            }
        }
    }
}
