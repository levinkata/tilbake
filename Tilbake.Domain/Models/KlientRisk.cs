using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public class KlientRisk
    {
        public Guid ID { get; set; }
        public Guid KlientID { get; set; }
        public Guid RiskID { get; set; }

        public virtual Klient Klient { get; private set; }
        public virtual Risk Risk { get; private set; }

        public virtual IReadOnlyCollection<PolitikkRisk> PolitikkRisks { get; set; } = new HashSet<PolitikkRisk>();
        public virtual IReadOnlyCollection<QuoteItem> QuoteItems { get; set; } = new HashSet<QuoteItem>();
    }
}
