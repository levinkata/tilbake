using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Tilbake.Application.Resources
{
    public class AddressSaveResource
    {
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public Guid? CityId { get; set; }
        public Guid? ClientId { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? LossAdjusterId { get; set; }
        public Guid? RepairerId { get; set; }
        public Guid? TracingAgentId { get; set; }
        public Guid? AttorneyId { get; set; }
        public Guid? ThirdPartyId { get; set; }
        public Guid? TowTruckId { get; set; }
        public Guid? RoadsideAssistId { get; set; }

        //  Description
        public string CityName { get; set; }

        //  SelectLists
        public SelectList CityList { get; set; }
        public SelectList CountryList { get; set; }
    }
}
