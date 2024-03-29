﻿using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class InvoiceItem
{
    public Guid Id { get; set; }

    public Guid InvoiceId { get; set; }

    public Guid PolicyRiskId { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;

    public virtual PolicyRisk PolicyRisk { get; set; } = null!;
}
