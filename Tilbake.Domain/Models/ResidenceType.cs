using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class ResidenceType
    {
        public ResidenceType()
        {
            Contents = new HashSet<Content>();
            Houses = new HashSet<House>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<House> Houses { get; set; }
    }
}
