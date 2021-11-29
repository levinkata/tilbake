using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class ClientBankAccount
    {
        public ClientBankAccount()
        {
            Policies = new HashSet<Policy>();
        }

        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid BankAccountId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual BankAccount BankAccount { get; set; } = null!;
        public virtual Client Client { get; set; } = null!;
        public virtual ICollection<Policy> Policies { get; set; }
    }
}
