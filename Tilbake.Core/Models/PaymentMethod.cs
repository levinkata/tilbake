using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Policies = new HashSet<Policy>();
            Quotes = new HashSet<Quote>();
            Reconcilliations = new HashSet<Reconcilliation>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
        public virtual ICollection<Reconcilliation> Reconcilliations { get; set; }
    }
}
