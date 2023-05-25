using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Tax
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal TaxRate { get; set; }

    public DateTime TaxDate { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }
}
