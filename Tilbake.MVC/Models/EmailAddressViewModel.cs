using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class EmailAddressViewModel : BaseViewModel
    {
        public Guid ClientId { get; set; }

        [Display(Name = "Is primary?")]
        public bool IsPrimary { get; set; }
    }
}
