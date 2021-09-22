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

        //  Descriptions
        public string CityName { get; set; }
        
        //  Others
        public Guid CountryId { get; set;  }

        //  SelectLists
        public SelectList CityList { get; set; }
        public SelectList CountryList { get; set; }
    }
}