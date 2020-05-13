using System;
using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class QuotesViewModel
    {
        public Guid KlientID { get; set; }
        public IEnumerable<Quote> Quotes { get; set; }
    }
}
