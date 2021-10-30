using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
            Companies = new HashSet<Company>();
            InsurerBranches = new HashSet<InsurerBranch>();
        }

        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<InsurerBranch> InsurerBranches { get; set; }
    }
}
