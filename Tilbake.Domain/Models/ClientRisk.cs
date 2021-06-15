using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class ClientRisk
    {
        public ClientRisk()
        {
            PolicyRisks = new HashSet<PolicyRisk>();
            QuoteItems = new HashSet<QuoteItem>();
        }

        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid RiskId { get; set; }
        public Guid? AddedById { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Client Client { get; set; }
        public virtual Risk Risk { get; set; }
        public virtual ICollection<PolicyRisk> PolicyRisks { get; set; }
        public virtual ICollection<QuoteItem> QuoteItems { get; set; }
    }
}
