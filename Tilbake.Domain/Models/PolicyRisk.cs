using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class PolicyRisk
    {
        public PolicyRisk()
        {
            PolicyRiskClaims = new HashSet<PolicyRiskClaim>();
            PolicyRiskExtensions = new HashSet<PolicyRiskExtension>();
            ValuationFeeRefunds = new HashSet<ValuationFeeRefund>();
        }

        public Guid Id { get; set; }
        public Guid PolicyId { get; set; }
        public Guid ClientRiskId { get; set; }
        public Guid CoverTypeId { get; set; }
        public decimal SumInsured { get; set; }
        public decimal Premium { get; set; }
        public string Excess { get; set; }
        public string Description { get; set; }
        public Guid? AddedById { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ClientRisk ClientRisk { get; set; }
        public virtual CoverType CoverType { get; set; }
        public virtual Policy Policy { get; set; }
        public virtual ICollection<PolicyRiskClaim> PolicyRiskClaims { get; set; }
        public virtual ICollection<PolicyRiskExtension> PolicyRiskExtensions { get; set; }
        public virtual ICollection<ValuationFeeRefund> ValuationFeeRefunds { get; set; }
    }
}
