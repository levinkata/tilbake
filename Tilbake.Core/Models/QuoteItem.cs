using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class QuoteItem
{
    public Guid Id { get; set; }

    public Guid QuoteId { get; set; }

    public Guid CustomerRiskId { get; set; }

    public Guid CoverTypeId { get; set; }

    public string Description { get; set; } = null!;

    public decimal SumInsured { get; set; }

    public decimal Premium { get; set; }

    public string? Excess { get; set; }

    public decimal TaxAmount { get; set; }

    public bool IsExcessBuyBack { get; set; }

    public bool IsMotor { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public bool IsExcessRequired { get; set; }

    public virtual CustomerRisk CustomerRisk { get; set; } = null!;

    public virtual CoverType CoverType { get; set; } = null!;

    public virtual Quote Quote { get; set; } = null!;
}
