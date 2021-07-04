using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class PremiumRefundClaim
    {
        public Guid PremiumRefundId { get; set; }
        public int ClaimNumber { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Claim ClaimNumberNavigation { get; set; }
        public virtual PremiumRefund PremiumRefund { get; set; }
    }
}
