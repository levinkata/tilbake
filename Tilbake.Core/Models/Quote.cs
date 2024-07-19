using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Quote
{
    public Guid Id { get; set; }

    public Guid PortfolioCustomerId { get; set; }

    public int QuoteNumber { get; set; }

    public DateTime QuoteDate { get; set; }

    public Guid QuoteStatusId { get; set; }

    public Guid InsurerBranchId { get; set; }

    public string? CustomerInfo { get; set; }

    public string? InternalInfo { get; set; }

    public bool IsFulfilled { get; set; }

    public bool IsPaid { get; set; }

    public bool IsAccepted { get; set; }

    public bool IsRejected { get; set; }

    public bool IsPolicy { get; set; }

    public bool IsTravel { get; set; }

    public bool IsCancelled { get; set; }

    public Guid? EndorsementPolicyId { get; set; }

    public Guid? RenewalPolicyId { get; set; }

    public Guid? PolicyTypeId { get; set; }

    public Guid? PaymentMethodId { get; set; }

    public Guid? CustomerBankAccountId { get; set; }

    public Guid? PaymentTypeId { get; set; }

    public decimal Prorata { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual CustomerBankAccount? CustomerBankAccount { get; set; }

    public virtual InsurerBranch InsurerBranch { get; set; } = null!;

    public virtual PaymentMethod? PaymentMethod { get; set; }

    public virtual PaymentType? PaymentType { get; set; }

    public virtual PolicyType? PolicyType { get; set; }

    public virtual PortfolioCustomer PortfolioCustomer { get; set; } = null!;

    public virtual ICollection<QuoteItem> QuoteItems { get; set; } = new List<QuoteItem>();

    public virtual QuoteStatus QuoteStatus { get; set; } = null!;

    public virtual ICollection<ReceivableQuote> ReceivableQuotes { get; set; } = new List<ReceivableQuote>();
}
