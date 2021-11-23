using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class CountryViewModel : BaseViewModel
    {
        [Display(Name = "Dialing Code")]
        public string? DialingCode { get; set; }
    }
}
