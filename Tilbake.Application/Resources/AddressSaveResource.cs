using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Resources
{
    public class AddressSaveResource
    {
        public Guid PortfolioId { get; set; }

        [Display(Name = "Physical Address")]
        public string PhysicalAddress { get; set; }

        [Display(Name = "Postal Address")]
        public string PostalAddress { get; set; }

        [Display(Name = "City")]
        public Guid CityId { get; set; }
        public Guid? ClientId { get; set; }
        public Guid? LossAdjusterId { get; set; }
        public Guid? RepairerId { get; set; }
        public Guid? TracingAgentId { get; set; }
        public Guid? AttorneyId { get; set; }
        public Guid? ThirdPartyId { get; set; }
        public Guid? TowTruckId { get; set; }
        public Guid? RoadsideAssistId { get; set; }

        //  Other
        [Display(Name = "Country")]
        public Guid CountryId { get; set; }

        //  SelectLists
        public SelectList CityList { get; set; }
        public SelectList CountryList { get; set; }




    }
}
