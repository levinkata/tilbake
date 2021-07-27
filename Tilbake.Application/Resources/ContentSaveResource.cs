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

        //  Descriptions
        [Display(Name = "Residence Use")]
        public string ResidenceUse { get; set; }

        [Display(Name = "Residence Type")]
        public string ResidenceType { get; set; }

        [Display(Name = "Roof Type")]        
        public string RoofType { get; set; }

        [Display(Name = "Wall Type")]
        public string WallType { get; set; }

        //  SelectLists

        public SelectList ResidenceUseList { get; set; }
        public SelectList ResidenceTypeList { get; set; }
        public SelectList RoofTypeList { get; set; }
        public SelectList WallTypeList { get; set; }   
    }
}