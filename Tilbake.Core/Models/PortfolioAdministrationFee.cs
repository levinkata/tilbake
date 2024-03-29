﻿using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class PortfolioAdministrationFee
{
    public Guid Id { get; set; }

    public Guid PortfolioId { get; set; }

    public Guid InsurerId { get; set; }

    public bool IsFeeFixed { get; set; }

    public decimal Rate { get; set; }

    public decimal Fee { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Insurer Insurer { get; set; } = null!;

    public virtual Portfolio Portfolio { get; set; } = null!;
}
