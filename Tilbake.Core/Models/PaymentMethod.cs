using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class PaymentMethod
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsBankAccountRequired { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<Policy> Policies { get; set; } = new List<Policy>();

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();

    public virtual ICollection<Reconcilliation> Reconcilliations { get; set; } = new List<Reconcilliation>();
}
