using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class Bank
    {
        public Guid ID { get; set; }

        [Display(Name = "Bank"), Required, StringLength(50)]
        public string Name { get; set; }

        public virtual IReadOnlyCollection<BankBranch> BankBranches { get; set; } = new HashSet<BankBranch>();
    }
}
