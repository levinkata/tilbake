using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            ReceivableInvoices = new HashSet<ReceivableInvoice>();
        }

        public Guid Id { get; set; }
        public Guid PolicyId { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Guid InvoiceStatusId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual InvoiceStatus InvoiceStatus { get; set; }
        public virtual Policy Policy { get; set; }
        public virtual ICollection<ReceivableInvoice> ReceivableInvoices { get; set; }
    }
}
