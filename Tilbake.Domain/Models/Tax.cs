using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class Tax
    {
        public Tax()
        {
            Invoices = new HashSet<Invoice>();
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

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Requisition> Requisitions { get; set; }
    }
}
