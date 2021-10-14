using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class Travel
    {
        public Travel()
        {
            Risks = new HashSet<Risk>();
            TravelBeneficiaries = new HashSet<TravelBeneficiary>();
        }

        public Guid Id { get; set; }
        public Guid TitleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PassportNumber { get; set; }
        public Guid CountryId { get; set; }
        public string PostalAddress { get; set; }
        public string PhysicalAddress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Destination { get; set; }
        public string PersonVisited { get; set; }
        public string Beneficiary { get; set; }
        public string DoctorName { get; set; }
        public string DoctorPhone { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Country Country { get; set; }
        public virtual Title Title { get; set; }
        public virtual ICollection<Risk> Risks { get; set; }
        public virtual ICollection<TravelBeneficiary> TravelBeneficiaries { get; set; }
    }
}
