using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class InsurerBranchSaveResource
    {
        public Guid InsurerId { get; set; }

        [Display(Name = "Branch")]
        public string Name { get; set; }

        [Display(Name = "Physical Address")]
        public string PhysicalAddress { get; set; }

        [Display(Name = "Postal Address")]        
        public string PostalAddress { get; set; }

        [Display(Name = "City")]        
        public Guid CityId { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Fax")]
        public string Fax { get; set; }

        [Display(Name = "Primary")]
        public string IsPrimary { get; set; }
        
        //  Descriptions
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Insurer")]
        public string Insurer { get; set; }

        //  Others
        [Display(Name = "Country")]
        public Guid CountryId { get; set;  }

        //  SelectLists
        public SelectList CityList { get; set; }
        public SelectList CountryList { get; set; }
    }
}