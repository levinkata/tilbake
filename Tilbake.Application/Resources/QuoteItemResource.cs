using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class QuoteItemResource
    {
        public Guid Id { get; set; }
        public Guid QuoteId { get; set; }
        public Guid ClientRiskId { get; set; }

        [Display(Name = "Insurer")]
        public Guid InsurerId { get; set; }

        [Display(Name = "Cover Type")]
        public Guid CoverTypeId { get; set; }

        [Display(Name = "Description")]
        public decimal Description { get; set; }


        [Display(Name = "Sum Insured")]
        public decimal SumInsured { get; set; }

        [Display(Name = "Premium")]
        public decimal Premium { get; set; }

        [Display(Name = "Excess")]
        public string Excess { get; set; }
    }
}
