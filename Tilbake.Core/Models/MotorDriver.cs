using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class MotorDriver
{
    public Guid MotorId { get; set; }

    public Guid DriverId { get; set; }

    public bool IsPrimary { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Driver Driver { get; set; } = null!;

    public virtual Motor Motor { get; set; } = null!;
}
