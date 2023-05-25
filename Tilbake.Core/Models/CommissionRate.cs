using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class CommissionRate
{
    public Guid Id { get; set; }

    public string RiskName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Rate { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }
}
