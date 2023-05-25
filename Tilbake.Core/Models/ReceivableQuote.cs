using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class ReceivableQuote
{
    public Guid QuoteId { get; set; }

    public Guid ReceivableId { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Quote Quote { get; set; } = null!;

    public virtual Receivable Receivable { get; set; } = null!;
}
