using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class AllRiskViewModel
    {
        public Guid Id { get; set; }
        public Guid QuoteItemId { get; set; }
        public Guid QuoteId { get; set; }
        public Guid PolicyRiskId { get; set; }

        [Display(Name = "Description")]
        public Guid RiskItemId { get; set; }

        public string RiskItem { get; set; }

        public Guid ModifiedBy { get; set; }

        //  SelectLists
        public SelectList RiskItemList { get; set; }
    }
}