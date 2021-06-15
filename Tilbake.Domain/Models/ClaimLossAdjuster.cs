﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class ClaimLossAdjuster
    {
        public int ClaimNumber { get; set; }
        public Guid LossAdjusterId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Claim ClaimNumberNavigation { get; set; }
        public virtual LossAdjuster LossAdjuster { get; set; }
    }
}