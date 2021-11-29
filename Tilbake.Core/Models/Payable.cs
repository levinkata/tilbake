using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class Payable
    {
        public Payable()
        {
            PayableRequisitions = new HashSet<PayableRequisition>();
        }

        public Guid Id { get; set; }
        public string Reference { get; set; } = null!;
        public DateTime? PayableDate { get; set; }
        public Guid? PaymentTypeId { get; set; }
        public decimal? Amount { get; set; }
        public string? BatchNumber { get; set; }
        public bool? Void { get; set; }
        public string? VoidReason { get; set; }
        public Guid? AddedById { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual PaymentType? PaymentType { get; set; }
        public virtual ICollection<PayableRequisition> PayableRequisitions { get; set; }
    }
}
