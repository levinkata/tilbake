﻿using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class InvoiceItem
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid PolicyRiskId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual PolicyRisk PolicyRisk { get; set; }
    }
}
