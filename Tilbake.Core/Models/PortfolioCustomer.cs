using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class PortfolioCustomer
{
    public Guid Id { get; set; }

    public Guid PortfolioId { get; set; }

    public Guid CustomerId { get; set; }

    public Guid CustomerStatusId { get; set; }

    public bool IsWithdrawal { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<Beneficiary> Beneficiaries { get; set; } = new List<Beneficiary>();

    public virtual Customer Customer { get; set; } = null!;

    public virtual CustomerStatus CustomerStatus { get; set; } = null!;

    public virtual ICollection<Policy> Policies { get; set; } = new List<Policy>();

    public virtual Portfolio Portfolio { get; set; } = null!;

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();

    public virtual ICollection<Travel> Travels { get; set; } = new List<Travel>();

    public virtual ICollection<Withdrawal> Withdrawals { get; set; } = new List<Withdrawal>();
}
