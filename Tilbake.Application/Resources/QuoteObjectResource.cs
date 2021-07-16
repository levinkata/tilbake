using System;
using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Resources
{
    public class QuoteObjectResource
    {
        public Guid PortfolioClientId { get; set; }
        public Quote Quote { get; set; }
        public List<Motor> Motors { get; set; }
        public List<QuoteItem> QuotesItems  { get; set; }
    }
}
