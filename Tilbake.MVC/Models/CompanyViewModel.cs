using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Tilbake.MVC.Models
{
    public class CompanyViewModel  : BaseViewModel
    {
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public Guid CityId { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string TaxNumber { get; set; }

        public Guid CountryId { get; set; }
        public CityViewModel City { get; set; }

        public SelectList CityList { get; set; }
    }
}
