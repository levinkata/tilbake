using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class Policy
    {
        public Policy()
        {
            Invoices = new HashSet<Invoice>();
            PolicyRenewals = new HashSet<PolicyRenewal>();
            PolicyRisks = new HashSet<PolicyRisk>();
            Premia = new HashSet<Premium>();
            PremiumRefunds = new HashSet<PremiumRefund>();
        }

        public Guid Id { get; set; }
        public Guid PortfolioClientId { get; set; }
        public int PolicyNumber { get; set; }
        public string InsurerPolicyNumber { get; set; }
        public Guid PolicyTypeId { get; set; }
        public int RunDay { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid? ClientBankAccountId { get; set; }
        public Guid InsurerId { get; set; }
        public DateTime CoverStartDate { get; set; }
        public DateTime CoverEndDate { get; set; }
        public DateTime InceptionDate { get; set; }
        public Guid PolicyStatusId { get; set; }
        public Guid SalesTypeId { get; set; }
        public string Comment { get; set; }
        public Guid? AddedById { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ClientBankAccount ClientBankAccount { get; set; }
        public virtual Insurer Insurer { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual PolicyStatus PolicyStatus { get; set; }
        public virtual PolicyType PolicyType { get; set; }
        public virtual PortfolioClient PortfolioClient { get; set; }
        public virtual SalesType SalesType { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<PolicyRenewal> PolicyRenewals { get; set; }
        public virtual ICollection<PolicyRisk> PolicyRisks { get; set; }
        public virtual ICollection<Premium> Premia { get; set; }
        public virtual ICollection<PremiumRefund> PremiumRefunds { get; set; }
    }
}
