using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class ClientCarrier
    {
        public Guid ClientId { get; set; }
        public Guid CarrierId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Carrier Carrier { get; set; }
        public virtual Client Client { get; set; }
    }
}
