using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Resources
{
    public class ClientCarrierSaveResource
    {
        [Display(Name = "Carriers")]
        public Guid[] CarrierIds { get; set; }

        public MultiSelectList CarrierList { get; set; }
    }
}
