using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class ResidenceUse
    {
        public ResidenceUse()
        {
            Contents = new HashSet<Content>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Content> Contents { get; set; }
    }
}
