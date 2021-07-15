using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class QuoteItem
    {
        public Guid Id { get; set; }
        public Guid QuoteId { get; set; }
        public Guid ClientRiskId { get; set; }
        public Guid? InsurerId { get; set; }
        public Guid CoverTypeId { get; set; }
        public string Description { get; set; }
        public decimal SumInsured { get; set; }
        public decimal Premium { get; set; }
        public string Excess { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ClientRisk ClientRisk { get; set; }
        public virtual CoverType CoverType { get; set; }
        public virtual Insurer Insurer { get; set; }
        public virtual Quote Quote { get; set; }
    }
}
