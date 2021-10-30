using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class DriverType
    {
        public DriverType()
        {
            Motors = new HashSet<Motor>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Motor> Motors { get; set; }
    }
}
