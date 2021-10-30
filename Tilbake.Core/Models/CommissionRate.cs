using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class CommissionRate
    {
        public Guid Id { get; set; }
        public string RiskName { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
