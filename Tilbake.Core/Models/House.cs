﻿using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class House
    {
        public House()
        {
            Risks = new HashSet<Risk>();
        }

        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; }
        public Guid ResidenceTypeId { get; set; }
        public Guid RoofTypeId { get; set; }
        public Guid WallTypeId { get; set; }
        public Guid HouseConditionId { get; set; }
        public bool BurglarAlarm { get; set; }
        public bool BurglarBars { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual HouseCondition HouseCondition { get; set; }
        public virtual ResidenceType ResidenceType { get; set; }
        public virtual RoofType RoofType { get; set; }
        public virtual WallType WallType { get; set; }
        public virtual ICollection<Risk> Risks { get; set; }
    }
}