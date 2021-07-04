using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class ClaimThirdParty
    {
        public int ClaimNumber { get; set; }
        public Guid ThirdPartyId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Claim ClaimNumberNavigation { get; set; }
        public virtual ThirdParty ThirdParty { get; set; }
    }
}
