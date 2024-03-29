﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.MVC.Models
{
    public class BuildingViewModel
    {
        public Guid Id { get; set; }
        public Guid QuoteItemId { get; set; }
        public Guid QuoteId { get; set; }
        public Guid PolicyRiskId { get; set; }

        [Display(Name = "Physical Address")]
        public string PhysicalAddress { get; set; }

        [Display(Name = "Residence Type")]
        public Guid ResidenceTypeId { get; set; }

        [Display(Name = "Residence Use")]
        public Guid ResidenceUseId { get; set; }

        [Display(Name = "Roof Type")]
        public Guid RoofTypeId { get; set; }

        [Display(Name = "Wall Type")]
        public Guid WallTypeId { get; set; }

        [Display(Name = "Building Condition")]
        public Guid BuildingConditionId { get; set; }

        [Display(Name = "Burglar Alarm")]
        public bool IsBurglarAlarm { get; set; }

        [Display(Name = "Burglar Bars")]
        public bool IsBurglarBars { get; set; }

        [Display(Name = "Rented Out")]
        public bool IsRentedOut { get; set; }

        [Display(Name = "Unoccupied")]
        public bool IsUnoccupied { get; set; }

        [Display(Name = "Unoccupied Period")]
        public string UnoccupancyPeriod { get; set; }

        [Display(Name = "House Sitters")]
        public bool IsUseHouseSitters { get; set; }

        [Display(Name = "Keep Dogs")]
        public bool IsKeepDogs { get; set; }

        [Display(Name = "Security Gates")]
        public bool IsSecurityGates { get; set; }

        [Display(Name = "Armed Response")]
        public bool IsArmedResponse { get; set; }

        [Display(Name = "Armed Response Name")]
        public string ArmedResponseName { get; set; }

        [Display(Name = "Electronic Gate")]
        public bool IsElectronicGate { get; set; }

        [Display(Name = "Electric Fence")]
        public bool IsElectricFence { get; set; }

        [Display(Name = "Security Complex")]
        public bool IsSecurityComplex { get; set; }

        [Display(Name = "Retirement Village")]
        public bool IsRetirementVillage { get; set; }

        [Display(Name = "Adjacent Open Area")]
        public bool IsAdjacentOpenArea { get; set; }

        [Display(Name = "Bond Holder")]
        public string BondHolder { get; set; }

        //  Descriptions

        public virtual BuildingConditionViewModel BuildingCondition { get; set; }
        public virtual ResidenceUseViewModel ResidenceUse { get; set; }
        public virtual ResidenceTypeViewModel ResidenceType { get; set; }
        public virtual RoofTypeViewModel RoofType { get; set; }
        public virtual WallTypeViewModel WallType { get; set; }

        //  SelectLists
        public SelectList BuildingConditionList { get; set; }
        public SelectList ResidenceUseList { get; set; }
        public SelectList ResidenceTypeList { get; set; }
        public SelectList RoofTypeList { get; set; }
        public SelectList WallTypeList { get; set; }
    }
}
