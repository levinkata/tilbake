using System;
using System.Collections.Generic;

namespace Tilbake.MVC.Models
{
    public class QuotePolicyObjectViewModel
    {
        public Guid Id { get; set; }
        public PolicyViewModel Policy { get; set; }
        public QuoteViewModel Quote { get; set; }
        public List<QuoteItemViewModel> QuoteItems { get; set; }
    }
}
