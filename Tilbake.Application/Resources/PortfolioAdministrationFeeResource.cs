using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Resources
{
    public class PortfolioAdministrationFeeResource
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

        public InsurerResource Insurer { get; set; }

        //  Selectlist
        public SelectList InsurerList { get; set; }
    }
}
