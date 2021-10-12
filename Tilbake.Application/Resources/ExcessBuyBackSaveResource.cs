using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public  class ExcessBuyBackSaveResource
    {
        public Guid Id { get; set; }
        public Guid PortfolioClientId { get; set; }

        [Display(Name = "Cover Type")]
        public Guid CoverTypeId { get; set; }

        public Guid ParentPolicyId { get; set; }

        [Display(Name = "Motor")]
        public Guid MotorId { get; set; }
        public Guid? AddedBy { get; set; }

        //  SelectLists
        public SelectList CoverTypelList { get; set; }
    }
}
