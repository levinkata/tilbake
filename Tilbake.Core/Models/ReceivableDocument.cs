using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class ReceivableDocument
{
    public Guid ReceivableId { get; set; }

    public Guid DocumentId { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Document Document { get; set; } = null!;

    public virtual Receivable Receivable { get; set; } = null!;
}
