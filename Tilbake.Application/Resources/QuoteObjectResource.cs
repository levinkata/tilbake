using System;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Resources
{
    public class QuoteObjectResource
    {
        public Guid ClientId { get; set; }

        public Quote Quote { get; set; }
        public QuoteItem[] QuoteItems  { get; set; }

        //  Risk Arrays
        public AllRisk[] AllRisks { get; set; }
        public Content[] Contents { get; set; }
        public House[] Houses { get; set; }
        public Motor[] Motors { get; set; }
    }
}
