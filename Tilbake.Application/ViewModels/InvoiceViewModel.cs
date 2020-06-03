using System;
using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class InvoiceViewModel
    {
        public Guid KlientID { get; set; }
        public Invoice Invoice { get; set; }

        private readonly List<InvoiceItem> invoiceitems = new List<InvoiceItem>();
        public List<InvoiceItem> InvoiceItems { get { return invoiceitems; } }
    }
}
