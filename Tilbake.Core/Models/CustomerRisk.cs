using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class CustomerRisk
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public Guid RiskId { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<CustomerRiskDocument> CustomerRiskDocuments { get; set; } = new List<CustomerRiskDocument>();

    public virtual ICollection<PolicyRisk> PolicyRisks { get; set; } = new List<PolicyRisk>();

    public virtual ICollection<QuoteItem> QuoteItems { get; set; } = new List<QuoteItem>();

    public virtual Risk Risk { get; set; } = null!;
}
