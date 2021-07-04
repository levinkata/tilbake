using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class Receivable
    {
        public Receivable()
        {
            ReceivableInvoices = new HashSet<ReceivableInvoice>();
        }

        public Guid Id { get; set; }
        public string Reference { get; set; }
        public DateTime? ReceivableDate { get; set; }
        public Guid PaymentTypeId { get; set; }
        public decimal? Amount { get; set; }
        public string BatchNumber { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual PaymentType PaymentType { get; set; }
        public virtual ICollection<ReceivableInvoice> ReceivableInvoices { get; set; }
    }
}
