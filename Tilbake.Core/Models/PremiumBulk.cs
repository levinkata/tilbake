using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class PremiumBulk
{
    public Guid Id { get; set; }

    public Guid PortfolioCustomerId { get; set; }

    public string IdNumber { get; set; } = null!;

    public int PolicyNumber { get; set; }

    public string? FirstName { get; set; }

    public string LastName { get; set; } = null!;

    public decimal? Amount { get; set; }

    public DateTime? DateAdded { get; set; }
}
