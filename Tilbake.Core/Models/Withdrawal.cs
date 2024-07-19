using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Withdrawal
{
    public Guid Id { get; set; }

    public Guid PortfolioCustomerId { get; set; }

    public string Reference { get; set; } = null!;

    public DateTime ReferenceDate { get; set; }

    public Guid RequestedById { get; set; }

    public DateTime WithdrawalDate { get; set; }

    public bool IsCleared { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual PortfolioCustomer PortfolioCustomer { get; set; } = null!;
}
