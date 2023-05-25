using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Insurer
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public byte[]? ImageFile { get; set; }

    public byte[]? Signature { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<InsurerBranch> InsurerBranches { get; set; } = new List<InsurerBranch>();

    public virtual ICollection<PortfolioAdministrationFee> PortfolioAdministrationFees { get; set; } = new List<PortfolioAdministrationFee>();

    public virtual ICollection<PortfolioExcessBuyBack> PortfolioExcessBuyBacks { get; set; } = new List<PortfolioExcessBuyBack>();

    public virtual ICollection<PortfolioPolicyFee> PortfolioPolicyFees { get; set; } = new List<PortfolioPolicyFee>();

    public virtual ICollection<RatingMotorDiscount> RatingMotorDiscounts { get; set; } = new List<RatingMotorDiscount>();

    public virtual ICollection<RatingMotorExcess> RatingMotorExcesses { get; set; } = new List<RatingMotorExcess>();

    public virtual ICollection<RatingMotorPremium> RatingMotorPremia { get; set; } = new List<RatingMotorPremium>();

    public virtual ICollection<RatingMotor> RatingMotors { get; set; } = new List<RatingMotor>();
}
