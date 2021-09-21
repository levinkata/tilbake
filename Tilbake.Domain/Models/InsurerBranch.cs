using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class InsurerBranch
    {
        public Guid Id { get; set; }
        public Guid InsurerId { get; set; }
        public string Name { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public Guid CityId { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual City City { get; set; }
    }
}
