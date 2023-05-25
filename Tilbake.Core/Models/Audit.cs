using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Audit
{
    public Guid Id { get; set; }

    public string UserId { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string TableName { get; set; } = null!;

    public DateTime DateTime { get; set; }

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    public string? AffectedColumns { get; set; }

    public string? PrimaryKey { get; set; }
}
