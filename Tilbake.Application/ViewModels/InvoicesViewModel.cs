using System;
using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class InvoicesViewModel
    {
        public Guid KlientID { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; }
    }
}
