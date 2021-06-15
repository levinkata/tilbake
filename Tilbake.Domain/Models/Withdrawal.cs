﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class Withdrawal
    {
        public Guid Id { get; set; }
        public Guid PortfolioClientId { get; set; }
        public string Reference { get; set; }
        public DateTime ReferenceDate { get; set; }
        public Guid RequestedById { get; set; }
        public DateTime WithdrawalDate { get; set; }
        public bool IsCleared { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual PortfolioClient PortfolioClient { get; set; }
    }
}