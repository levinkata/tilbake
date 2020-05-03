using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Enums
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male = 1,

        [Display(Name = "Female")]
        Female = 2,

        [Display(Name = "Unspecified")]
        Unspecified = 3
    }
}
