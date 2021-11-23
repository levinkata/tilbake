using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class InsurerBranchViewModel : BaseViewModel
    {
        public Guid InsurerId { get; set; }

        [Display(Name = "Physical Address")]
        public string? PhysicalAddress { get; set; }

        [Display(Name = "Postal Address")]
        public string? PostalAddress { get; set; }

        [Display(Name = "City")]
        public Guid CityId { get; set; }

        [Display(Name = "Phone")]
        public string? Phone { get; set; }

        [Display(Name = "Fax")]
        public string? Fax { get; set; }

        [Display(Name = "Primary")]
        public bool? IsPrimary { get; set; }

        public InsurerViewModel? Insurer { get; set; }

        [Display(Name = "City")]
        public CityViewModel? City { get; set; }

        //  Others
        [Display(Name = "Country")]
        public Guid CountryId { get; set; }

        //  SelectLists
        public SelectList? CityList { get; set; }
        public SelectList? CountryList { get; set; }
    }
}
