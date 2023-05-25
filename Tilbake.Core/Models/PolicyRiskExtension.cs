using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class PolicyRiskExtension
{
    public Guid PolicyRiskId { get; set; }

    public Guid ExtensionId { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Extension Extension { get; set; } = null!;

    public virtual PolicyRisk PolicyRisk { get; set; } = null!;
}
