using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class PayeeBankAccount
    {
        public Guid PayeeId { get; set; }
        public Guid BankAccountId { get; set; }
        public Guid? AddedById { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual BankAccount BankAccount { get; set; }
        public virtual Payee Payee { get; set; }
    }
}
