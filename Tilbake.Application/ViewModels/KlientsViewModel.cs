using System;
using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class KlientsViewModel
    {
        public Guid PortfolioID { get; set; }
        public IEnumerable<Klient> Klients { get; set; }
    }
}
