using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class EmailAddress
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public string Name { get; set; } = null!;
        public bool IsPrimary { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Client Client { get; set; } = null!;
    }
}
