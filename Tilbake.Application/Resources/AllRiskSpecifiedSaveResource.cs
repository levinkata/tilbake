using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tilbake.Application.Resources
{
    public class AllRiskSpecifiedSaveResource
    {
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

        public Guid AddedBy { get; set; }

        //  SelectLists
        public SelectList RiskItemList { get; set; }
    }
}