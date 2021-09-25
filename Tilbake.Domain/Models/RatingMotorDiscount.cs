using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class RatingMotorDiscount
    {
        public RatingMotorDiscount()
        {
            PortfolioRatingMotorDiscounts = new HashSet<PortfolioRatingMotorDiscount>();
        }

        public Guid Id { get; set; }
        public Guid InsurerId { get; set; }
        public int ClaimFreeGroup { get; set; }
        public decimal Rate { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Insurer Insurer { get; set; }
        public virtual ICollection<PortfolioRatingMotorDiscount> PortfolioRatingMotorDiscounts { get; set; }
    }
}
