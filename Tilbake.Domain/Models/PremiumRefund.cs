﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class PremiumRefund
    {
        public PremiumRefund()
        {
            PremiumRefundClaims = new HashSet<PremiumRefundClaim>();
        }

        public Guid Id { get; set; }
        public Guid PolicyId { get; set; }
        public string Reference { get; set; }
        public DateTime ReferenceDate { get; set; }
        public Guid RequestedById { get; set; }
        public int FromMonth { get; set; }
        public int ToMonth { get; set; }
        public int FromYear { get; set; }
        public int ToYear { get; set; }
        public decimal? Amount { get; set; }
        public string Reason { get; set; }
        public bool IsWithdrawal { get; set; }
        public Guid RefundStatusId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Policy Policy { get; set; }
        public virtual ICollection<PremiumRefundClaim> PremiumRefundClaims { get; set; }
    }
}