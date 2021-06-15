using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class ValuationFeeRefund
    {
        public ValuationFeeRefund()
        {
            ValuationFeeRefundClaims = new HashSet<ValuationFeeRefundClaim>();
        }

        public Guid Id { get; set; }
        public Guid PolicyRiskId { get; set; }
        public string Reference { get; set; }
        public DateTime ReferenceDate { get; set; }
        public decimal Amount { get; set; }
        public Guid RequestedById { get; set; }
        public Guid RefundStatusId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual PolicyRisk PolicyRisk { get; set; }
        public virtual RefundStatus RefundStatus { get; set; }
        public virtual ICollection<ValuationFeeRefundClaim> ValuationFeeRefundClaims { get; set; }
    }
}
