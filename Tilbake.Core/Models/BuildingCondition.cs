using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class BuildingCondition
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<Building> Buildings { get; set; } = new List<Building>();

    public virtual ICollection<Content> Contents { get; set; } = new List<Content>();
}
