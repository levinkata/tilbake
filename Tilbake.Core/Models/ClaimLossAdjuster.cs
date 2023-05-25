using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class ClaimLossAdjuster
{
    public int ClaimNumber { get; set; }

    public Guid LossAdjusterId { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual LossAdjuster LossAdjuster { get; set; } = null!;
}
