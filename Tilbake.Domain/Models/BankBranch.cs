using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class BankBranch
    {
        public Guid ID { get; set; }

        [Display(Name = "Bank")]
        public Guid BankID { get; set; }

        [Display(Name = "Branch"), Required, StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Branch Code"), Required, StringLength(50)]
        public string BIC { get; set; }

        [Display(Name = "Swift Code"), Required, StringLength(50)]
        public string SwiftCode { get; set; }

        public virtual Bank Bank { get; private set; }
        public virtual IReadOnlyCollection<BankAccount> BankAccounts { get; set; } = new HashSet<BankAccount>();
    }
}
