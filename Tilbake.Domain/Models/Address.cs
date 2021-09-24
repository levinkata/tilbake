﻿using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class Address
    {
        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public Guid? CityId { get; set; }
        public Guid? ClientId { get; set; }
        public Guid? LossAdjusterId { get; set; }
        public Guid? RepairerId { get; set; }
        public Guid? TracingAgentId { get; set; }
        public Guid? AttorneyId { get; set; }
        public Guid? ThirdPartyId { get; set; }
        public Guid? TowTruckId { get; set; }
        public Guid? RoadsideAssistId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Attorney Attorney { get; set; }
        public virtual City City { get; set; }
        public virtual Client Client { get; set; }
        public virtual LossAdjuster LossAdjuster { get; set; }
        public virtual Repairer Repairer { get; set; }
        public virtual RoadsideAssist RoadsideAssist { get; set; }
        public virtual ThirdParty ThirdParty { get; set; }
        public virtual TowTruck TowTruck { get; set; }
        public virtual TracingAgent TracingAgent { get; set; }
    }
}
