using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class BankBranch
{
    public Guid Id { get; set; }

    public Guid BankId { get; set; }

    public string Name { get; set; } = null!;

    public string SortCode { get; set; } = null!;

    public string SwiftCode { get; set; } = null!;

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Bank Bank { get; set; } = null!;

    public virtual ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
}
