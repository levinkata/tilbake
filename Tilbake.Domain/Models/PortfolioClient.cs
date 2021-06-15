using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class PortfolioClient
    {
        public PortfolioClient()
        {
            Policies = new HashSet<Policy>();
            Withdrawals = new HashSet<Withdrawal>();
        }

        public Guid Id { get; set; }
        public Guid PortfolioId { get; set; }
        public Guid ClientId { get; set; }
        public bool IsWithdrawal { get; set; }
        public Guid? AddedById { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Client Client { get; set; }
        public virtual Portfolio Portfolio { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }
        public virtual ICollection<Withdrawal> Withdrawals { get; set; }
    }
}
