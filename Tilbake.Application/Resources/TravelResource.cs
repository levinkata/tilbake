using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [Display(Name = "Departure Date")]
        public DateTime DepartureDate { get; set; }

        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }

        [Display(Name = "Destination")]
        public string Destination { get; set; }

        [Display(Name = "Person Visited")]
        public string PersonVisited { get; set; }

        [Display(Name = "Beneficiary")]
        public string Beneficiary { get; set; }

        [Display(Name = "Doctor's Name")]
        public string DoctorName { get; set; }

        [Display(Name = "Doctor's Phone")]
        public string DoctorPhone { get; set; }
        public Guid? ModifiedBy { get; set; }

        public List<TravelBeneficiaryResource> TravelBeneficiaries { get; } = new();

        public ClientResource Client { get; set; }
        public PortfolioClientResource PortfolioClient { get; set; }
    }
}
