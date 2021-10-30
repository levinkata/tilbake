﻿using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Payables = new HashSet<Payable>();
            Receivables = new HashSet<Receivable>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Payable> Payables { get; set; }
        public virtual ICollection<Receivable> Receivables { get; set; }
    }
}