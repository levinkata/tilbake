using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class InvoiceStatus
    {
        public Guid ID { get; set; }

        [Display(Name = "Invoice Status"), Required, StringLength(50)]
        public string Name { get; set; }
    }
}
