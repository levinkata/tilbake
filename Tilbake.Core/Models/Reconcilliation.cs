using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class Reconcilliation
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool IsReconcilled { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Invoice Invoice { get; set; } = null!;
        public virtual PaymentMethod PaymentMethod { get; set; } = null!;
    }
}
