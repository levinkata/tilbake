using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class PolicyBulk
{
    public Guid Id { get; set; }

    public Guid PortfolioClientId { get; set; }

    public string IdNumber { get; set; } = null!;

    public int PolicyNumber { get; set; }

    public string? FirstName { get; set; }

    public string LastName { get; set; } = null!;

    public DateTime? DateAdded { get; set; }
}
