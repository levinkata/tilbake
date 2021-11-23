using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class CommissionRateViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Risk")]
        public string RiskName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Rate")]
        public decimal Rate { get; set; }

        //  Selects
        public SelectList RiskList { get; set;  }
    }
}
