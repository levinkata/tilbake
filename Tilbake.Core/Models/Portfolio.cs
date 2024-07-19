using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Portfolio
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsScheme { get; set; }

    public Guid? OwnerId { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<AspnetUserPortfolio> AspnetUserPortfolios { get; set; } = new List<AspnetUserPortfolio>();

    public virtual ICollection<Eftfile> Eftfiles { get; set; } = new List<Eftfile>();

    public virtual ICollection<FileTemplate> FileTemplates { get; set; } = new List<FileTemplate>();

    public virtual ICollection<PortfolioAdministrationFee> PortfolioAdministrationFees { get; set; } = new List<PortfolioAdministrationFee>();

    public virtual ICollection<PortfolioCustomer> PortfolioCustomers { get; set; } = new List<PortfolioCustomer>();

    public virtual ICollection<PortfolioExcessBuyBack> PortfolioExcessBuyBacks { get; set; } = new List<PortfolioExcessBuyBack>();

    public virtual ICollection<PortfolioPolicyFee> PortfolioPolicyFees { get; set; } = new List<PortfolioPolicyFee>();

    public virtual ICollection<PortfolioRatingMotorDiscount> PortfolioRatingMotorDiscounts { get; set; } = new List<PortfolioRatingMotorDiscount>();

    public virtual ICollection<PortfolioRatingMotorExcess> PortfolioRatingMotorExcesses { get; set; } = new List<PortfolioRatingMotorExcess>();

    public virtual ICollection<PortfolioRatingMotorPremium> PortfolioRatingMotorPremia { get; set; } = new List<PortfolioRatingMotorPremium>();

    public virtual ICollection<PortfolioRatingMotor> PortfolioRatingMotors { get; set; } = new List<PortfolioRatingMotor>();
}
