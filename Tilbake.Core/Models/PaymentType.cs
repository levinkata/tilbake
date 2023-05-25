using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class PaymentType
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<Payable> Payables { get; set; } = new List<Payable>();

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();

    public virtual ICollection<Receivable> Receivables { get; set; } = new List<Receivable>();
}
