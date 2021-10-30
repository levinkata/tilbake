using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class ClaimAttorney
    {
        public int ClaimNumber { get; set; }
        public Guid AttorneyId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Attorney Attorney { get; set; }
        public virtual Claim ClaimNumberNavigation { get; set; }
    }
}
