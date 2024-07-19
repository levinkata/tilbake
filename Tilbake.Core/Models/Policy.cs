using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Policy
{
    public Guid Id { get; set; }

    public Guid PortfolioCustomerId { get; set; }

    public Guid QuoteId { get; set; }

    public int PolicyNumber { get; set; }

    public string? InsurerPolicyNumber { get; set; }

    public Guid PolicyTypeId { get; set; }

    public int RunDay { get; set; }

    public Guid PaymentMethodId { get; set; }

    public Guid? CustomerBankAccountId { get; set; }

    public Guid InsurerBranchId { get; set; }

    public DateTime CoverStartDate { get; set; }

    public DateTime CoverEndDate { get; set; }

    public DateTime InceptionDate { get; set; }

    public int Version { get; set; }

    public Guid PolicyStatusId { get; set; }

    public Guid SalesTypeId { get; set; }

    public string? Comment { get; set; }

    public bool IsHoldCover { get; set; }

    public bool IsHoldCoverPlus { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual CustomerBankAccount? CustomerBankAccount { get; set; }

    public virtual InsurerBranch InsurerBranch { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;

    public virtual ICollection<PolicyRenewal> PolicyRenewals { get; set; } = new List<PolicyRenewal>();

    public virtual ICollection<PolicyRisk> PolicyRisks { get; set; } = new List<PolicyRisk>();

    public virtual PolicyStatus PolicyStatus { get; set; } = null!;

    public virtual PolicyType PolicyType { get; set; } = null!;

    public virtual PortfolioCustomer PortfolioCustomer { get; set; } = null!;

    public virtual ICollection<Premium> Premia { get; set; } = new List<Premium>();

    public virtual ICollection<PremiumInstallment> PremiumInstallments { get; set; } = new List<PremiumInstallment>();

    public virtual SalesType SalesType { get; set; } = null!;
}
