using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class AllRiskSaveResource
    {
        [Display(Name = "Description")]
        public Guid RiskItemId { get; set; }

        //  Descriptions
        [Display(Name = "Description")]
        public string RiskItem { get; set; }

        public Guid AddedBy { get; set; }

        //  SelectLists
        public SelectList RiskItemList { get; set; }
    }
}