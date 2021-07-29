using System;
using System.Collections.Generic;

namespace Tilbake.Application.Resources
{
    public class QuotePolicyObjectResource
    {
        public Guid Id { get; set; }
        public PolicySaveResource Policy { get; set; }
        public QuoteResource Quote { get; set; }
        public List<QuoteItemResource> QuoteItems { get; set; }
    }
}
