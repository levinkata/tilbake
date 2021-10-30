using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class Tax
    {
        public Tax()
        {
            Requisitions = new HashSet<Requisition>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal TaxRate { get; set; }
        public DateTime TaxDate { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Requisition> Requisitions { get; set; }
    }
}
