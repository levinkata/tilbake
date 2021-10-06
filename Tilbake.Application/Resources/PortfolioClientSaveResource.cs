using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class PortfolioClientSaveResource
    {
        public Guid PortfolioId { get; set; }
        public Guid ClientId { get; set; }

        [Display(Name = "Client Status")]
        public Guid ClientStatusId { get; set; }

        [Display(Name = "Title")]
        public Guid TitleId { get; set; }

        [Display(Name = "Client Type")]
        public Guid ClientTypeId { get; set; }

        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gender")]
        public Guid GenderId { get; set; }

        [Display(Name = "ID Document Type")]
        public Guid IdDocumentTypeId { get; set; }

        [Display(Name = "ID Number")]
        public string IdNumber { get; set; }

        [Display(Name = "Marital Status")]
        public Guid MaritalStatusId { get; set; }

        [Display(Name = "Nationality")]
        public Guid CountryId { get; set; }

        [MaxLength(50)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Occupation")]
        public Guid OccupationId { get; set; }

        //  Descriptions
        public string PortfolioName { get; set; }

        //  Carriers
        [Display(Name = "Carriers")]
        public Guid[] CarrierIds { get; set; }

        public MultiSelectList CarrierList { get; set; }

        //  ============================================

        //  Address
        [Display(Name = "Physical Address")]
        public string PhysicalAddress { get; set; }

        [Display(Name = "Postal Address")]
        public string PostalAddress { get; set; }

        [Display(Name = "City")]
        public Guid? CityId { get; set; }

        [Display(Name = "Country")]
        public Guid AddressCountryId { get; set; }

        public SelectList CityList { get; set; }
        public SelectList AddressCountryList { get; set; }

        //  ==========================================

        //  SelectLists

        public SelectList ClientTypeList { get; set; }
        public SelectList CountryList { get; set; }
        public SelectList GenderList { get; set; }
        public SelectList IdDocumentTypeList { get; set; }
        public SelectList MaritalStatusList { get; set; }
        public SelectList OccupationList { get; set; }
        public SelectList TitleList { get; set; }
    }
}
