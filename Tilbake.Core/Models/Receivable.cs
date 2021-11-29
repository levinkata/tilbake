using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class Receivable
    {
        public Receivable()
        {
            ReceivableDocuments = new HashSet<ReceivableDocument>();
            ReceivableInvoices = new HashSet<ReceivableInvoice>();
            ReceivableQuotes = new HashSet<ReceivableQuote>();
        }

        public Guid Id { get; set; }
        public string Reference { get; set; } = null!;
        public DateTime ReceivableDate { get; set; }
        public Guid PaymentTypeId { get; set; }
        public decimal Amount { get; set; }
        public string? BatchNumber { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual PaymentType PaymentType { get; set; } = null!;
        public virtual ICollection<ReceivableDocument> ReceivableDocuments { get; set; }
        public virtual ICollection<ReceivableInvoice> ReceivableInvoices { get; set; }
        public virtual ICollection<ReceivableQuote> ReceivableQuotes { get; set; }
    }
}
