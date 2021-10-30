using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class AspnetUserPortfolio
    {
        public string AspNetUserId { get; set; }
        public Guid PortfolioId { get; set; }
        public Guid? AddedById { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Portfolio Portfolio { get; set; }
    }
}
