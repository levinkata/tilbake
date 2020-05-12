using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.Domain.Models
{
    public class Invoice
    {
        public Guid ID { get; set; }

        [Display(Name = "Invoice Number"), Required, StringLength(50)]
        public int InvoiceNumber { get; set; }

        [Display(Name = "Invoice Date"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = true)]
        public DateTime InvoiceDate { get; set; }

        [Display(Name = "Invoice Status")]
        public Guid InvoiceStatusID { get; set; }

        public virtual InvoiceStatus Invoicetatus { get; private set; }
        public virtual IReadOnlyCollection<InvoiceItem> InvoiceItems { get; set; } = new HashSet<InvoiceItem>();
    }
}
