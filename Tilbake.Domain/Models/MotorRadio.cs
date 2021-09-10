﻿using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class MotorRadio
    {
        public Guid Id { get; set; }
        public Guid MotorId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public decimal? PurchaseValue { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Motor Motor { get; set; }
    }
}
