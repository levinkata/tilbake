using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class CoverType
    {
        public CoverType()
        {
            PolicyRisks = new HashSet<PolicyRisk>();
            QuoteItems = new HashSet<QuoteItem>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<PolicyRisk> PolicyRisks { get; set; }
        public virtual ICollection<QuoteItem> QuoteItems { get; set; }
    }
}
