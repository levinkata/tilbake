using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class TravelBeneficiary
    {
        public Guid Id { get; set; }
        public Guid TravelId { get; set; }
        public Guid TitleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PassportNumber { get; set; }
        public Guid CountryId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Country Country { get; set; }
        public virtual Title Title { get; set; }
        public virtual Travel Travel { get; set; }
    }
}
