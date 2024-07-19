using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class BankAccount
{
    public Guid Id { get; set; }

    public Guid BankBranchId { get; set; }

    public string AccountNumber { get; set; } = null!;

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual BankBranch BankBranch { get; set; } = null!;

    public virtual ICollection<CompanyBankAccount> CompanyBankAccounts { get; set; } = new List<CompanyBankAccount>();

    public virtual ICollection<CustomerBankAccount> CustomerBankAccounts { get; set; } = new List<CustomerBankAccount>();

    public virtual ICollection<PayeeBankAccount> PayeeBankAccounts { get; set; } = new List<PayeeBankAccount>();
}
