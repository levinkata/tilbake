using System;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Resources
{
    public class ClientCarrierResource
    {
        public Guid ClientId { get; set; }
        public Guid CarrierId { get; set; }

        public Carrier Carrier { get; set; }
    }
}
