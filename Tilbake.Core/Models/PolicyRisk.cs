using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class PolicyRisk
{
    public Guid Id { get; set; }

    public Guid PolicyId { get; set; }

    public Guid CustomerRiskId { get; set; }

    public Guid CoverTypeId { get; set; }

    public DateTime RiskDate { get; set; }

    public decimal SumInsured { get; set; }

    public decimal Premium { get; set; }

    public string? Excess { get; set; }

    public string? Description { get; set; }

    public decimal TaxAmount { get; set; }

    public bool IsActive { get; set; }

    public DateTime? DeactivateDate { get; set; }

    public bool IsMotor { get; set; }

    public bool IsExcessBuyBack { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual CoverType CoverType { get; set; } = null!;

    public virtual CustomerRisk CustomerRisk { get; set; } = null!;

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    public virtual Policy Policy { get; set; } = null!;

    public virtual ICollection<PolicyRiskClaim> PolicyRiskClaims { get; set; } = new List<PolicyRiskClaim>();

    public virtual ICollection<PolicyRiskExtension> PolicyRiskExtensions { get; set; } = new List<PolicyRiskExtension>();

    public virtual ICollection<PremiumRefund> PremiumRefunds { get; set; } = new List<PremiumRefund>();

    public virtual ICollection<ValuationFeeRefund> ValuationFeeRefunds { get; set; } = new List<ValuationFeeRefund>();
}
