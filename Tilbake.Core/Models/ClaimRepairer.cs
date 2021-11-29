using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class ClaimRepairer
    {
        public int ClaimNumber { get; set; }
        public Guid RepairerId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Repairer Repairer { get; set; } = null!;
    }
}
