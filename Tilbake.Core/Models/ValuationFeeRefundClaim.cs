﻿using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class ValuationFeeRefundClaim
    {
        public Guid ValuationFeeRefundId { get; set; }
        public int ClaimNumber { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ValuationFeeRefund ValuationFeeRefund { get; set; } = null!;
    }
}
