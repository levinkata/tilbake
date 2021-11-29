using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class Travel
    {
        public Travel()
        {
            Risks = new HashSet<Risk>();
            TravelBeneficiaries = new HashSet<TravelBeneficiary>();
        }

        public Guid Id { get; set; }
        public Guid PortfolioClientId { get; set; }
        public string PassportNumber { get; set; } = null!;
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Destination { get; set; } = null!;
        public string PersonVisited { get; set; } = null!;
        public string Beneficiary { get; set; } = null!;
        public string DoctorName { get; set; } = null!;
        public string DoctorPhone { get; set; } = null!;
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual PortfolioClient PortfolioClient { get; set; } = null!;
        public virtual ICollection<Risk> Risks { get; set; }
        public virtual ICollection<TravelBeneficiary> TravelBeneficiaries { get; set; }
    }
}
