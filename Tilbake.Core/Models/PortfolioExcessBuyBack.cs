using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class PortfolioExcessBuyBack
    {
        public Guid Id { get; set; }
        public Guid PortfolioId { get; set; }
        public Guid InsurerId { get; set; }
        public decimal ExcessRate { get; set; }
        public decimal BuyBackRate { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Insurer Insurer { get; set; } = null!;
        public virtual Portfolio Portfolio { get; set; } = null!;
    }
}
