﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class RefundStatus
    {
        public RefundStatus()
        {
            ValuationFeeRefunds = new HashSet<ValuationFeeRefund>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<ValuationFeeRefund> ValuationFeeRefunds { get; set; }
    }
}