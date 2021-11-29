using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class Title
    {
        public Title()
        {
            Clients = new HashSet<Client>();
            TravelBeneficiaries = new HashSet<TravelBeneficiary>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<TravelBeneficiary> TravelBeneficiaries { get; set; }
    }
}
