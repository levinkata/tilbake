using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
            Clients = new HashSet<Client>();
            TravelBeneficiaries = new HashSet<TravelBeneficiary>();
            Travels = new HashSet<Travel>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DialingCode { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<TravelBeneficiary> TravelBeneficiaries { get; set; }
        public virtual ICollection<Travel> Travels { get; set; }
    }
}
