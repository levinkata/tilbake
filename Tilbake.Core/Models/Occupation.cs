using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class Occupation
    {
        public Occupation()
        {
            Clients = new HashSet<Client>();
            Drivers = new HashSet<Driver>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
