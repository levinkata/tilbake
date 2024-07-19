using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class InterMediate
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? Flag { get; set; }
}
