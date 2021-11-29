using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class ExcessBuyBack
    {
        public ExcessBuyBack()
        {
            Risks = new HashSet<Risk>();
        }

        public Guid Id { get; set; }
        public Guid? ParentPolicyId { get; set; }
        public Guid ParentQuoteId { get; set; }
        public Guid MotorId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Motor Motor { get; set; } = null!;
        public virtual Policy? ParentPolicy { get; set; }
        public virtual Quote ParentQuote { get; set; } = null!;
        public virtual ICollection<Risk> Risks { get; set; }
    }
}
