using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class AddressViewModel
    {
        public Guid PortfolioId { get; set; }
        public Guid Id { get; set; }

        [Display(Name = "Physical Address")]
        public string PhysicalAddress { get; set; }

        [Display(Name = "Postal Address")]
        public string? PostalAddress { get; set; }

        [Display(Name = "City")]
        public Guid CityId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? LossAdjusterId { get; set; }
        public Guid? RepairerId { get; set; }
        public Guid? TracingAgentId { get; set; }
        public Guid? AttorneyId { get; set; }
        public Guid? ThirdPartyId { get; set; }
        public Guid? TowTruckId { get; set; }
        public Guid? RoadsideAssistId { get; set; }

        public virtual CityViewModel? City { get; set; }

        //  Other
        [Display(Name = "Country")]
        public Guid CountryId { get; set; }

        //  SelectLists
        public SelectList? CityList { get; set; }
        public SelectList? CountryList { get; set; }
    }
}
