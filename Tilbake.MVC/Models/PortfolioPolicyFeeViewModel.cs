using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using Tilbake.Core.Models;

namespace Tilbake.MVC.Models
{
    public class PortfolioPolicyFeeViewModel
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
        
        public InsurerViewModel Insurer { get; set; }

        //  SelectList
        public SelectList InsurerList { get; set; }
    }
}
