using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class MobileNumberSaveResource
    {
        public Guid ClientId { get; set; }

        [Display(Name = "Mobile")]        
        public string Name { get; set; }

        [Display(Name = "Is Primary?")]        
        public bool IsPrimary { get; set; }
        public Guid? AddedBy { get; set; }
    }
}