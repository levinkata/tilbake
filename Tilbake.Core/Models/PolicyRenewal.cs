using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class PolicyRenewal
    {
        public Guid Id { get; set; }
        public Guid PolicyId { get; set; }
        public DateTime RenewalDateDue { get; set; }
        public bool IsRenewed { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Policy Policy { get; set; }
    }
}
