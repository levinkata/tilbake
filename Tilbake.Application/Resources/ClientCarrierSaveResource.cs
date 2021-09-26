using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Resources
{
    public class ClientCarrierSaveResource
    {
        public Guid ClientId { get; set; }
        public Guid CarrierId { get; set; }

        public Guid[] CarrierIds { get; set; }

        public Carrier Carrier { get; set; }

        public MultiSelectList CarrierList { get; set; }
    }
}
