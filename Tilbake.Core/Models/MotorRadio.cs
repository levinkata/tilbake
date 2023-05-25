using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class MotorRadio
{
    public Guid Id { get; set; }

    public Guid MotorId { get; set; }

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string SerialNumber { get; set; } = null!;

    public decimal? PurchaseValue { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Motor Motor { get; set; } = null!;
}
