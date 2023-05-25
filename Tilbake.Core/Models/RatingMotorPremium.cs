using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class RatingMotorPremium
{
    public Guid Id { get; set; }

    public Guid InsurerId { get; set; }

    public decimal MinimumMonthly { get; set; }

    public decimal MinimumAnnual { get; set; }

    public decimal MinimumAnnualThirdParty { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Insurer Insurer { get; set; } = null!;

    public virtual ICollection<PortfolioRatingMotorPremium> PortfolioRatingMotorPremia { get; set; } = new List<PortfolioRatingMotorPremium>();
}
