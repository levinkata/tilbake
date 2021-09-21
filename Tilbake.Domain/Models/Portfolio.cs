using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class Portfolio
    {
        public Portfolio()
        {
            AspnetUserPortfolios = new HashSet<AspnetUserPortfolio>();
            Eftfiles = new HashSet<Eftfile>();
            FileTemplates = new HashSet<FileTemplate>();
            PortfolioAdministrationFees = new HashSet<PortfolioAdministrationFee>();
            PortfolioClients = new HashSet<PortfolioClient>();
            PortfolioPolicyFees = new HashSet<PortfolioPolicyFee>();
            RatingMotorDiscounts = new HashSet<RatingMotorDiscount>();
            RatingMotorExcesses = new HashSet<RatingMotorExcess>();
            RatingMotorPremia = new HashSet<RatingMotorPremium>();
            RatingMotors = new HashSet<RatingMotor>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsScheme { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<AspnetUserPortfolio> AspnetUserPortfolios { get; set; }
        public virtual ICollection<Eftfile> Eftfiles { get; set; }
        public virtual ICollection<FileTemplate> FileTemplates { get; set; }
        public virtual ICollection<PortfolioAdministrationFee> PortfolioAdministrationFees { get; set; }
        public virtual ICollection<PortfolioClient> PortfolioClients { get; set; }
        public virtual ICollection<PortfolioPolicyFee> PortfolioPolicyFees { get; set; }
        public virtual ICollection<RatingMotorDiscount> RatingMotorDiscounts { get; set; }
        public virtual ICollection<RatingMotorExcess> RatingMotorExcesses { get; set; }
        public virtual ICollection<RatingMotorPremium> RatingMotorPremia { get; set; }
        public virtual ICollection<RatingMotor> RatingMotors { get; set; }
    }
}
