using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class PolicyRiskViewModel
    {
        public Guid Id { get; set; }
        public Guid PolicyId { get; set; }
        public Guid ClientRiskId { get; set; }

        [Display(Name = "Cover Type")]
        public Guid CoverTypeId { get; set; }

        [Display(Name = "Risk Date")]
        public DateTime RiskDate { get; set; }

        [Display(Name = "Sum Insured")]
        public decimal SumInsured { get; set; }

        [Display(Name = "Premium")]
        public decimal Premium { get; set; }

        [Display(Name = "Excess")]
        public string Excess { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public CoverTypeViewModel CoverType { get; set; }

        //  SelectLists
        public SelectList CoverTypeList { get; set; }
    }
}
