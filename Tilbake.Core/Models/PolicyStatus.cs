﻿using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class PolicyStatus
    {
        public PolicyStatus()
        {
            Policies = new HashSet<Policy>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}
