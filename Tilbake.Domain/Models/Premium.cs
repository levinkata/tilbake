using System;
using System.Collections.Generic;

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
        public bool IsRefunded { get; set; }
        public decimal Commission { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal PolicyFee { get; set; }
        public decimal AdministrationFee { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Policy Policy { get; set; }
    }
}
