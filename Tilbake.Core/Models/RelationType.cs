using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class RelationType
    {
        public RelationType()
        {
            Beneficiaries = new HashSet<Beneficiary>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Beneficiary> Beneficiaries { get; set; }
    }
}
