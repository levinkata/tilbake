using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class RatingMotorDiscount
{
    public Guid Id { get; set; }

    public Guid InsurerId { get; set; }

    public int ClaimFreeGroup { get; set; }

    public decimal Rate { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Insurer Insurer { get; set; } = null!;

    public virtual ICollection<PortfolioRatingMotorDiscount> PortfolioRatingMotorDiscounts { get; set; } = new List<PortfolioRatingMotorDiscount>();
}
