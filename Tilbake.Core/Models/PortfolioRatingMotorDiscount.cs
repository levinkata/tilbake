using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class PortfolioRatingMotorDiscount
    {
        public Guid PortfolioId { get; set; }
        public Guid RatingMotorDiscountId { get; set; }
        public Guid? AddedById { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Portfolio Portfolio { get; set; }
        public virtual RatingMotorDiscount RatingMotorDiscount { get; set; }
    }
}
