using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Eftfile
{
    public Guid Id { get; set; }

    public Guid PortfolioId { get; set; }

    public string Name { get; set; } = null!;

    public int Month { get; set; }

    public int Year { get; set; }

    public DateTime RunDate { get; set; }

    public int TotalEntries { get; set; }

    public decimal TotalAmount { get; set; }

    public string DocumentPath { get; set; } = null!;

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Portfolio Portfolio { get; set; } = null!;
}
