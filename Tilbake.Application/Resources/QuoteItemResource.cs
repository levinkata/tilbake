using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class QuoteItemResource
    {
        public Guid ClientRiskId { get; set; }
        public Guid Id { get; set; }
        public Guid QuoteId { get; set; }

        [Display(Name = "Cover Type")]
        public Guid CoverTypeId { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Sum Insured")]
        public decimal SumInsured { get; set; }

        [Display(Name = "Premium")]
        public decimal Premium { get; set; }

        [Display(Name = "Excess")]
        public string Excess { get; set; }

        //  Descriptions
        [Display(Name = "Cover Type")]
        public string CoverType { get; set; }

        //  SelectLists
        public SelectList CoverTypeList { get; set; }
    }
}
