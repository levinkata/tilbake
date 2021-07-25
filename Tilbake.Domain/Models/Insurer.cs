using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class Insurer
    {
        public Insurer()
        {
            Policies = new HashSet<Policy>();
            PortfolioAdministrationFees = new HashSet<PortfolioAdministrationFee>();
            PortfolioPolicyFees = new HashSet<PortfolioPolicyFee>();
            QuoteItems = new HashSet<QuoteItem>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
        public virtual ICollection<PortfolioAdministrationFee> PortfolioAdministrationFees { get; set; }
        public virtual ICollection<PortfolioPolicyFee> PortfolioPolicyFees { get; set; }
        public virtual ICollection<QuoteItem> QuoteItems { get; set; }
    }
}
