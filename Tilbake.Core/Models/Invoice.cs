using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceItems = new HashSet<InvoiceItem>();
            ReceivableInvoices = new HashSet<ReceivableInvoice>();
            Reconcilliations = new HashSet<Reconcilliation>();
        }

        public Guid Id { get; set; }
        public Guid PolicyId { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Amount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public Guid InvoiceStatusId { get; set; }
        public decimal ReducingBalance { get; set; }
        public decimal InstallmentAmount { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual InvoiceStatus InvoiceStatus { get; set; } = null!;
        public virtual Policy Policy { get; set; } = null!;
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
        public virtual ICollection<ReceivableInvoice> ReceivableInvoices { get; set; }
        public virtual ICollection<Reconcilliation> Reconcilliations { get; set; }
    }
}
