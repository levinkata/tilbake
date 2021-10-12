using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class TravelBeneficiaryResource
    {
        public Guid Id { get; set; }
        public Guid TravelId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Passport Number")]
        public string PassportNumber { get; set; }

        [Display(Name = "Nationality")]
        public Guid CountryId { get; set; }

        public Guid? ModifiedBy { get; set; }

        public CountryResource Country { get; set; }
        public TravelResource Travel { get; set; }

        //  SelectLists
        public SelectList CountryList { get; set; }
    }
}
