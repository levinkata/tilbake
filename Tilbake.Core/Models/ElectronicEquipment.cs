﻿using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class ElectronicEquipment
    {
        public ElectronicEquipment()
        {
            Risks = new HashSet<Risk>();
        }

        public Guid Id { get; set; }
        public Guid RiskItemId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual RiskItem RiskItem { get; set; } = null!;
        public virtual ICollection<Risk> Risks { get; set; }
    }
}
