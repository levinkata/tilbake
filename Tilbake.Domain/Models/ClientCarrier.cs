using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class ClientCarrier
    {
        public Guid ClientId { get; set; }
        public Guid CarrierId { get; set; }

        public virtual Carrier Carrier { get; set; }
        public virtual Client Client { get; set; }
    }
}
