using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using Tilbake.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class ClientCarrierResource
    {
        public Guid PortfolioId {get; set; }
        public Guid ClientId { get; set; }
        public Guid CarrierId { get; set; }

        [Display(Name = "Carriers")]
        public Guid[] CarrierIds { get; set; }

        public Carrier Carrier { get; set; }

        public MultiSelectList CarrierList { get; set; }
    }
}
