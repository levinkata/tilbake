using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Enums
{
    public enum  Carrier
    {
        [Display(Name = "Email")]
        Email = 1,

        [Display(Name = "Phone")]
        Phone = 2,

        [Display(Name = "Postal Mail")]
        Postal = 3
    }
}
