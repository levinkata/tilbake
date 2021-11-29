using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class Bank
    {
        public Bank()
        {
            BankBranches = new HashSet<BankBranch>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<BankBranch> BankBranches { get; set; }
    }
}
