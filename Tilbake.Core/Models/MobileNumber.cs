using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class MobileNumber
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public string Name { get; set; } = null!;

    public bool IsPrimary { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
