using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class RatingMotorPremium
    {
        public RatingMotorPremium()
        {
            PortfolioRatingMotorPremia = new HashSet<PortfolioRatingMotorPremium>();
        }

        public Guid Id { get; set; }
        public Guid InsurerId { get; set; }
        public decimal MinimumMonthly { get; set; }
        public decimal MinimumAnnual { get; set; }
        public decimal MinimumAnnualThirdParty { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Insurer Insurer { get; set; }
        public virtual ICollection<PortfolioRatingMotorPremium> PortfolioRatingMotorPremia { get; set; }
    }
}
