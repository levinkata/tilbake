using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class PortfoliosViewModel
    {
        public IEnumerable<Portfolio> Portfolios { get; set; }
    }
}
