using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class RatingMotorExcess
{
    public Guid Id { get; set; }

    public Guid InsurerId { get; set; }

    public decimal StartValue { get; set; }

    public decimal EndValue { get; set; }

    public string? RateLocal { get; set; }

    public string? RateImport { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Insurer Insurer { get; set; } = null!;

    public virtual ICollection<PortfolioRatingMotorExcess> PortfolioRatingMotorExcesses { get; set; } = new List<PortfolioRatingMotorExcess>();
}
