using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class Payee
    {
        public Payee()
        {
            PayeeBankAccounts = new HashSet<PayeeBankAccount>();
        }

        public Guid Id { get; set; }
        public Guid PayeeTypeId { get; set; }
        public Guid? AddedById { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual PayeeType PayeeType { get; set; }
        public virtual ICollection<PayeeBankAccount> PayeeBankAccounts { get; set; }
    }
}
