using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class PremiumInstallment
{
    public Guid Id { get; set; }

    public Guid PolicyId { get; set; }

    public DateTime InstallmentDate { get; set; }

    public decimal Amount { get; set; }

    public bool Paid { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Policy Policy { get; set; } = null!;
}
