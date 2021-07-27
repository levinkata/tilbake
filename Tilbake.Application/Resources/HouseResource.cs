using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class HouseResource
    {
        public Guid Id { get; set; }
        public Guid QuoteItemId { get; set; }

        [Display(Name = "Physical Address")]        
        public string PhysicalAddress { get; set; }

        [Display(Name = "Residence Type")]
        public Guid ResidenceTypeId { get; set; }

        [Display(Name = "Roof Type")]
        public Guid RoofTypeId { get; set; }

        [Display(Name = "Wall Type")]
        public Guid WallTypeId { get; set; }

        [Display(Name = "House Condition")]
        public Guid HouseConditionId { get; set; }

        [Display(Name = "Baurglar Alarm")]
        public bool BurglarAlarm { get; set; }

        [Display(Name = "Burglar Bars")]
        public bool BurglarBars { get; set; }

        //  Descriptions
        [Display(Name = "House Condition")]
        public string HouseCondition { get; set; }

        [Display(Name = "Residence Type")]
        public string ResidenceType { get; set; }

        [Display(Name = "Roof Type")]        
        public string RoofType { get; set; }

        [Display(Name = "Wall Type")]
        public string WallType { get; set; }

        //  SelectLists
        public SelectList HouseConditionList { get; set; }
        public SelectList ResidenceTypeList { get; set; }
        public SelectList RoofTypeList { get; set; }
        public SelectList WallTypeList { get; set; }    
    }
}