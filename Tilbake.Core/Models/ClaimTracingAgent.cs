﻿using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class ClaimTracingAgent
    {
        public int ClaimNumber { get; set; }
        public Guid TracingAgentId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Claim ClaimNumberNavigation { get; set; }
        public virtual TracingAgent TracingAgent { get; set; }
    }
}