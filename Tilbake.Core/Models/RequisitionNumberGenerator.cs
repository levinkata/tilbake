using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class RequisitionNumberGenerator
{
    public Guid Id { get; set; }

    public int RequisitionNumber { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }
}
