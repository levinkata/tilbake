using System;
using System.Collections.Generic;

namespace Tilbake.MVC.Models
{
    public class PortfolioCustomerSearchViewModel
    {
        public Guid PortfolioId { get; set; }
        public string? PortfolioName { get; set; }
        public string? SearchString { get; set; }
        public IEnumerable<CustomerViewModel>? Customers { get; set; }
    }
}
