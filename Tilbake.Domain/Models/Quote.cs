using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class Quote
    {
        public Quote()
        {
            QuoteItems = new HashSet<QuoteItem>();
            ReceivableQuotes = new HashSet<ReceivableQuote>();
        }

        public Guid Id { get; set; }
        public Guid PortfolioClientId { get; set; }
        public int QuoteNumber { get; set; }
        public DateTime QuoteDate { get; set; }
        public Guid QuoteStatusId { get; set; }
        public Guid? InsurerBranchId { get; set; }
        public Guid? SalesTypeId { get; set; }
        public Guid? PolicyTypeId { get; set; }
        public Guid? PaymentMethodId { get; set; }
        public string ClientInfo { get; set; }
        public string InternalInfo { get; set; }
        public int RunDay { get; set; }
        public bool IsFulfilled { get; set; }
        public bool IsPaid { get; set; }
        public bool IsPolicySet { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual InsurerBranch InsurerBranch { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual PolicyType PolicyType { get; set; }
        public virtual PortfolioClient PortfolioClient { get; set; }
        public virtual QuoteStatus QuoteStatus { get; set; }
        public virtual SalesType SalesType { get; set; }
        public virtual ICollection<QuoteItem> QuoteItems { get; set; }
        public virtual ICollection<ReceivableQuote> ReceivableQuotes { get; set; }
    }
}
