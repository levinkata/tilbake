using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class CommissionRateSaveResource
    {
        [Display(Name = "Risk")]
        public string RiskName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Rate")]
        public decimal Rate { get; set; }
    }
}
