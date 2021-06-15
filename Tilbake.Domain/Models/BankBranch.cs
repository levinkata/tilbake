using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class BankBranch
    {
        public BankBranch()
        {
            BankAccounts = new HashSet<BankAccount>();
        }

        public Guid Id { get; set; }
        public Guid BankId { get; set; }
        public string Name { get; set; }
        public string SortCode { get; set; }
        public string SwiftCode { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Bank Bank { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
    }
}
