using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class PremiumRefund
{
    public Guid Id { get; set; }

    public Guid PolicyRiskId { get; set; }

    public string Reference { get; set; } = null!;

    public DateTime ReferenceDate { get; set; }

    public Guid RequestedById { get; set; }

    public int Month { get; set; }

    public int Year { get; set; }

    public decimal Amount { get; set; }

    public string Reason { get; set; } = null!;

    public bool IsWithdrawal { get; set; }

    public Guid RefundStatusId { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual PolicyRisk PolicyRisk { get; set; } = null!;

    public virtual ICollection<PremiumRefundClaim> PremiumRefundClaims { get; set; } = new List<PremiumRefundClaim>();

    public virtual RefundStatus RefundStatus { get; set; } = null!;
}
