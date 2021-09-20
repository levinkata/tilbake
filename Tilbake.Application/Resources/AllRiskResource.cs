using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class AllRiskResource
    {
        public Guid Id { get; set; }
        public Guid QuoteItemId { get; set; }
        public Guid QuoteId { get; set; }
        public Guid PolicyRiskId { get; set; }

        [Display(Name = "Description")]
        public Guid RiskItemId { get; set; }

        //  Descriptions
        [Display(Name = "Description")]
        public string RiskItem { get; set; }

        //  SelectLists
        public SelectList RiskItemList { get; set; }
    }
}