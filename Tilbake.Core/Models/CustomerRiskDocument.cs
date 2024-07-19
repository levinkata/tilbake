using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class CustomerRiskDocument
{
    public Guid CustomerRiskId { get; set; }

    public Guid DocumentId { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual CustomerRisk CustomerRisk { get; set; } = null!;

    public virtual Document Document { get; set; } = null!;
}
