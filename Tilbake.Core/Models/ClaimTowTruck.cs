﻿using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class ClaimTowTruck
{
    public int ClaimNumber { get; set; }

    public Guid TowTruckId { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual TowTruck TowTruck { get; set; } = null!;
}
