using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class QuoteNumberGenerator
{
    public Guid Id { get; set; }

    public int QuoteNumber { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }
}
