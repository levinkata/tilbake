using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class ChartOfAccount
    {
        public ChartOfAccount()
        {
            Requisitions = new HashSet<Requisition>();
        }

        public Guid Id { get; set; }
        public string Glcode { get; set; }
        public string Description { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Requisition> Requisitions { get; set; }
    }
}
