using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class ChartOfAccount
{
    public Guid Id { get; set; }

    public string Glcode { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<Requisition> Requisitions { get; set; } = new List<Requisition>();
}
