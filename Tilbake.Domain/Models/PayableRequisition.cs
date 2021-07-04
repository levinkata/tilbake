using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class PayableRequisition
    {
        public Guid RequisitionId { get; set; }
        public Guid PayableId { get; set; }
        public Guid? AddedById { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Payable Payable { get; set; }
        public virtual Requisition Requisition { get; set; }
    }
}
