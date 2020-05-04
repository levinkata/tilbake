using System;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class KlientViewModel
    {
        public Guid PortfolioID { get; set; }
        public Klient Klient { get; set; }
    }
}
