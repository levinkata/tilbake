using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class ChartOfAccount
    {
        public ChartOfAccount()
        {
            Requisitions = new HashSet<Requisition>();
        }

        public Guid Id { get; set; }
        public string Glcode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Requisition> Requisitions { get; set; }
    }
}
