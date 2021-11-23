using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class TravelBeneficiaryViewModel
    {
        public Guid Id { get; set; }
        public Guid TravelId { get; set; }

        [Display(Name = "Title")]
        public Guid TitleId { get; set; }

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

        public CountryViewModel Country { get; set; }
        public TitleViewModel Title { get; set; }

        public TravelViewModel Travel { get; set; }

        //  SelectLists
        public SelectList CountryList { get; set; }
        public SelectList TitleList { get; set; }
    }
}
