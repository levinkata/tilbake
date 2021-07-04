using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class ThirdParty
    {
        public ThirdParty()
        {
            ClaimThirdParties = new HashSet<ClaimThirdParty>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IdNumber { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public Guid? AddedById { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<ClaimThirdParty> ClaimThirdParties { get; set; }
    }
}
