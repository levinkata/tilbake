using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class ClientBankAccount
    {
        public Guid ClientId { get; set; }
        public Guid BankAccountId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual BankAccount BankAccount { get; set; }
        public virtual Client Client { get; set; }
    }
}
