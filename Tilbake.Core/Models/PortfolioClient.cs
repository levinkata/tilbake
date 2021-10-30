using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class PortfolioClient
    {
        public PortfolioClient()
        {
            Beneficiaries = new HashSet<Beneficiary>();
            Policies = new HashSet<Policy>();
            Quotes = new HashSet<Quote>();
            Travels = new HashSet<Travel>();
            Withdrawals = new HashSet<Withdrawal>();
        }

        public Guid Id { get; set; }
        public Guid PortfolioId { get; set; }
        public Guid ClientId { get; set; }
        public Guid ClientStatusId { get; set; }
        public bool IsWithdrawal { get; set; }
        public Guid? AddedById { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Client Client { get; set; }
        public virtual ClientStatus ClientStatus { get; set; }
        public virtual Portfolio Portfolio { get; set; }
        public virtual ICollection<Beneficiary> Beneficiaries { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
        public virtual ICollection<Travel> Travels { get; set; }
        public virtual ICollection<Withdrawal> Withdrawals { get; set; }
    }
}
