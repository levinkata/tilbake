using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class Policy
    {
        public Policy()
        {
            ExcessBuyBacks = new HashSet<ExcessBuyBack>();
            Invoices = new HashSet<Invoice>();
            PolicyRenewals = new HashSet<PolicyRenewal>();
            PolicyRisks = new HashSet<PolicyRisk>();
            Premia = new HashSet<Premium>();
            PremiumRefunds = new HashSet<PremiumRefund>();
        }

        public Guid Id { get; set; }
        public Guid PortfolioClientId { get; set; }
        public Guid QuoteId { get; set; }
        public int PolicyNumber { get; set; }
        public string? InsurerPolicyNumber { get; set; }
        public Guid PolicyTypeId { get; set; }
        public int RunDay { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid? ClientBankAccountId { get; set; }
        public Guid InsurerBranchId { get; set; }
        public DateTime CoverStartDate { get; set; }
        public DateTime CoverEndDate { get; set; }
        public DateTime InceptionDate { get; set; }
        public int Version { get; set; }
        public Guid PolicyStatusId { get; set; }
        public Guid SalesTypeId { get; set; }
        public string? Comment { get; set; }
        public Guid? AddedById { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ClientBankAccount? ClientBankAccount { get; set; }
        public virtual InsurerBranch InsurerBranch { get; set; } = null!;
        public virtual PaymentMethod PaymentMethod { get; set; } = null!;
        public virtual PolicyStatus PolicyStatus { get; set; } = null!;
        public virtual PolicyType PolicyType { get; set; } = null!;
        public virtual PortfolioClient PortfolioClient { get; set; } = null!;
        public virtual Quote Quote { get; set; } = null!;
        public virtual SalesType SalesType { get; set; } = null!;
        public virtual ICollection<ExcessBuyBack> ExcessBuyBacks { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<PolicyRenewal> PolicyRenewals { get; set; }
        public virtual ICollection<PolicyRisk> PolicyRisks { get; set; }
        public virtual ICollection<Premium> Premia { get; set; }
        public virtual ICollection<PremiumRefund> PremiumRefunds { get; set; }
    }
}
