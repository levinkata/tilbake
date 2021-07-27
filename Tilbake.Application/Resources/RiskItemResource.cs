using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class RiskItemResource
    {
        public Guid Id { get; set; }

        [Display(Description = "Name")]
        public string Description { get; set; }
    }
}