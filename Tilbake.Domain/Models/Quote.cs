using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class Quote
    {
        public Quote()
        {
            QuoteItems = new HashSet<QuoteItem>();
        }

        public Guid Id { get; set; }
        public int QuoteNumber { get; set; }
        public DateTime QuoteDate { get; set; }
        public Guid QuoteStatusId { get; set; }
        public string ClientInfo { get; set; }
        public string InternalInfo { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual QuoteStatus QuoteStatus { get; set; }
        public virtual ICollection<QuoteItem> QuoteItems { get; set; }
    }
}
