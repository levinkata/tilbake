using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class ContentSaveResource
    {
        [Display(Name = "Roof Type")]
        public Guid RoofTypeId { get; set; }

        [Display(Name = "Wall Type")]
        public Guid WallTypeId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Physical Address")]        
        public string PhysicalAddress { get; set; }

        [Display(Name = "Residence Type")]
        public Guid ResidenceTypeId { get; set; }

        [Display(Name = "Residence Use")]
        public Guid ResidenceUseId { get; set; }

        public Guid BuildingConditionId { get; set; }
        public bool IsBurglarAlarm { get; set; }
        public bool IsBurglarBars { get; set; }
        public bool IsRentedOut { get; set; }
        public bool IsUnoccupied { get; set; }
        public string UnoccupancyPeriod { get; set; }
        public bool IsUseHouseSitters { get; set; }
        public bool IsKeepDogs { get; set; }
        public bool IsSecurityGates { get; set; }
        public bool IsArmedResponse { get; set; }
        public string ArmedResponseName { get; set; }
        public bool IsElectronicGate { get; set; }
        public bool IsElectricFence { get; set; }
        public bool IsSecurityComplex { get; set; }
        public bool IsRetirementVillage { get; set; }
        public bool IsAdjacentOpenArea { get; set; }
        public string BondHolder { get; set; }

        //  Descriptions

        [Display(Name = "Building Condition")]
        public string BuildingCondition { get; set; }

        [Display(Name = "Residence Use")]
        public string ResidenceUse { get; set; }

        [Display(Name = "Residence Type")]
        public string ResidenceType { get; set; }

        [Display(Name = "Roof Type")]
        public string RoofType { get; set; }

        [Display(Name = "Wall Type")]
        public string WallType { get; set; }

        //  SelectLists
        public SelectList BuildingConditionList { get; set; }
        public SelectList ResidenceUseList { get; set; }
        public SelectList ResidenceTypeList { get; set; }
        public SelectList RoofTypeList { get; set; }
        public SelectList WallTypeList { get; set; }   
    }
}