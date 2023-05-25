using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class DocumentType
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}
