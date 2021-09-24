using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class CompanyBankAccount
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid BankAccountId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual BankAccount BankAccount { get; set; }
        public virtual Company Company { get; set; }
    }
}
