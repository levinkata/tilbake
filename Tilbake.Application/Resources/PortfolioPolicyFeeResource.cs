using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class PortfolioPolicyFeeResource
    {
        public Guid Id { get; set; }
        public Guid PortfolioId { get; set; }

        [Display(Name = "Insurer")]
        public Guid InsurerId { get; set; }

        [Display(Name = "Is Fixed Fee?")]
        public bool IsFeeFixed { get; set; }

        [Display(Name = "Rate")]
        public decimal Rate { get; set; }

        [Display(Name = "Fee")]
        public decimal Fee { get; set; }

        [Display(Name = "Insurer")]
        public string Insurer { get; set; }

        //  SelectList
        public SelectList InsurerList { get; set; }
    }
}
