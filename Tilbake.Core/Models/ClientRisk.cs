using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class ClientRisk
{
    public Guid Id { get; set; }

    public Guid ClientId { get; set; }

    public Guid RiskId { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<ClientRiskDocument> ClientRiskDocuments { get; set; } = new List<ClientRiskDocument>();

    public virtual ICollection<PolicyRisk> PolicyRisks { get; set; } = new List<PolicyRisk>();

    public virtual ICollection<QuoteItem> QuoteItems { get; set; } = new List<QuoteItem>();

    public virtual Risk Risk { get; set; } = null!;
}
