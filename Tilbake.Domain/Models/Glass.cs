using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class Glass
    {
        public Glass()
        {
            Risks = new HashSet<Risk>();
        }

        public Guid Id { get; set; }
        public Guid RiskItemId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual RiskItem RiskItem { get; set; }
        public virtual ICollection<Risk> Risks { get; set; }
    }
}
