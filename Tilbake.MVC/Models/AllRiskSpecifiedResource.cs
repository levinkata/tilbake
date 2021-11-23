using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tilbake.MVC.Models
{
    public class AllRiskSpecifiedViewModel
    {
        public Guid Id { get; set; }
        public Guid QuoteItemId { get; set; }
        public Guid QuoteId { get; set; }
        public Guid PolicyRiskId { get; set; }

        [Display(Name = "Description")]
        public Guid RiskItemId { get; set; }

        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        
        //  Descriptions
        [Display(Name = "Description")]
        public string RiskItem { get; set; }

        public Guid ModifiedBy { get; set; }

        //  SelectLists
        public SelectList RiskItemList { get; set; }
    }
}