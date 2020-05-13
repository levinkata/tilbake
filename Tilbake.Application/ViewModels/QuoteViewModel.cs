using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class QuoteViewModel
    {
        public Guid KlientID { get; set; }
        public Quote Quote { get; set; }

        private readonly List<QuoteItem> quoteitems = new List<QuoteItem>();
        public List<QuoteItem> QuoteItems { get { return quoteitems;  } }
    }
}
