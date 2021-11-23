using System;
using System.Collections.Generic;

namespace Tilbake.MVC.Models
{
    public class PortfolioClientSearchViewModel
    {
        public Guid PortfolioId { get; set; }
        public string? PortfolioName { get; set; }
        public string? SearchString { get; set; }
        public IEnumerable<ClientViewModel>? Clients { get; set; }
    }
}
