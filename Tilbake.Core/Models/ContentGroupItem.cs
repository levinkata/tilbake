using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class ContentGroupItem
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<ContentItem> ContentItems { get; set; } = new List<ContentItem>();
}
