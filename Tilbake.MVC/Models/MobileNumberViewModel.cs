using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class MobileNumberViewModel : BaseViewModel
    {
        public Guid ClientId { get; set; }

        [Display(Name = "Is primary?")]
        public bool IsPrimary { get; set; }
    }
}
