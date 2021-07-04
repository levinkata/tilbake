using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class Title
    {
        public Title()
        {
            Clients = new HashSet<Client>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
