using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class Insurer
    {
        public Insurer()
        {
            InsurerBranches = new HashSet<InsurerBranch>();
            Policies = new HashSet<Policy>();
            PortfolioAdministrationFees = new HashSet<PortfolioAdministrationFee>();
            PortfolioPolicyFees = new HashSet<PortfolioPolicyFee>();
            Quotes = new HashSet<Quote>();
            RatingMotorDiscounts = new HashSet<RatingMotorDiscount>();
            RatingMotorExcesses = new HashSet<RatingMotorExcess>();
            RatingMotorPremia = new HashSet<RatingMotorPremium>();
            RatingMotors = new HashSet<RatingMotor>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] ImageFile { get; set; }
        public byte[] Signature { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<InsurerBranch> InsurerBranches { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }
        public virtual ICollection<PortfolioAdministrationFee> PortfolioAdministrationFees { get; set; }
        public virtual ICollection<PortfolioPolicyFee> PortfolioPolicyFees { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
        public virtual ICollection<RatingMotorDiscount> RatingMotorDiscounts { get; set; }
        public virtual ICollection<RatingMotorExcess> RatingMotorExcesses { get; set; }
        public virtual ICollection<RatingMotorPremium> RatingMotorPremia { get; set; }
        public virtual ICollection<RatingMotor> RatingMotors { get; set; }
    }
}
