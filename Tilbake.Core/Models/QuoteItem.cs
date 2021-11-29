using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class QuoteItem
    {
        public Guid Id { get; set; }
        public Guid QuoteId { get; set; }
        public Guid ClientRiskId { get; set; }
        public Guid CoverTypeId { get; set; }
        public string Description { get; set; } = null!;
        public decimal SumInsured { get; set; }
        public decimal Premium { get; set; }
        public string? Excess { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ClientRisk ClientRisk { get; set; } = null!;
        public virtual CoverType CoverType { get; set; } = null!;
        public virtual Quote Quote { get; set; } = null!;
    }
}
