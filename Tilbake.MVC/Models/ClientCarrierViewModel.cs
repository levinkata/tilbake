using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class ClientCarrierViewModel
    {
        public Guid ClientId { get; set; }
        public Guid CarrierId { get; set; }

        [Display(Name = "Carriers")]
        public List<Guid>? CarrierIds { get; set; } = new();

        public virtual CarrierViewModel? Carrier { get; set; }

        public MultiSelectList? CarrierList { get; set; }
    }
}
