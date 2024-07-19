using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string CoverageDetails { get; set; } = null!;

    public decimal BasePrice { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }
}
