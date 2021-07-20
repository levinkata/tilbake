using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class Company
    {
        public Company()
        {
            Addresses = new HashSet<Address>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
