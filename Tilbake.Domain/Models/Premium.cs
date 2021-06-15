using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class Premium
    {
        public Guid Id { get; set; }
        public Guid PolicyId { get; set; }
        public DateTime PremiumDate { get; set; }
        public int PremiumMonth { get; set; }
        public int PremiumYear { get; set; }
        public decimal Amount { get; set; }
        public Guid PremiumTypeId { get; set; }
        public bool IsRefunded { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Policy Policy { get; set; }
        public virtual PremiumType PremiumType { get; set; }
    }
}
