using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class BankAccount
    {
        public Guid ID { get; set; }

        [Display(Name = "Bank Branch")]
        public Guid BankBranchID { get; set; }

        [Display(Name = "Account Number"), Required, StringLength(50)]
        public string AccountNumber { get; set; }

        public virtual BankBranch BankBranch { get; private set; }
        public virtual IReadOnlyCollection<KlientBankAccount> KlientBankAccounts { get; set; } = new HashSet<KlientBankAccount>();
    }
}
