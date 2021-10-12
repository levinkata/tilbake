using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class TravelSaveResource
    {
        public Guid PortfolioClientId { get; set; }
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
        public Guid? AddedBy { get; set; }

        public List<TravelBeneficiaryResource> TravelBeneficiaries { get; } = new();
    }
}
