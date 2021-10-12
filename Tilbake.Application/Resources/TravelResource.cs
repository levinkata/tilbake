using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class TravelResource
    {
        public Guid Id { get; set; }
        public Guid PortfolioClientId { get; set; }
        public Guid QuoteItemId { get; set; }
        public Guid QuoteId { get; set; }
        public Guid PolicyRiskId { get; set; }

        [Display(Name = "Passport Number")]
        public string PassportNumber { get; set; }

        [Display(Name = "Depature Date")]
        public DateTime DepatureDate { get; set; }

        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }

        [Display(Name = "Destination")]
        public string Destination { get; set; }

        [Display(Name = "Person Visited")]
        public string PersonVisited { get; set; }

        [Display(Name = "Doctor's name")]
        public string DoctorName { get; set; }

        [Display(Name = "Doctor's Contact")]
        public string DoctorContact { get; set; }
        public Guid? ModifiedBy { get; set; }

        public List<TravelBeneficiaryResource> TravelBeneficiaries { get; } = new();
    }
}
