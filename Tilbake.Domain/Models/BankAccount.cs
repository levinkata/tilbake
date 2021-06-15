using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class BankAccount
    {
        public BankAccount()
        {
            ClientBankAccounts = new HashSet<ClientBankAccount>();
            PayeeBankAccounts = new HashSet<PayeeBankAccount>();
        }

        public Guid Id { get; set; }
        public Guid BankBranchId { get; set; }
        public string AccountNumber { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual BankBranch BankBranch { get; set; }
        public virtual ICollection<ClientBankAccount> ClientBankAccounts { get; set; }
        public virtual ICollection<PayeeBankAccount> PayeeBankAccounts { get; set; }
    }
}
