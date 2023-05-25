using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class ApplicationSession
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Value { get; set; } = null!;

    public Guid UserId { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }
}
