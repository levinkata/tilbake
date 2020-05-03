using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Enums
{
    public enum KlientType
    {
        [Display(Name = "Individual")]
        Individual = 1,

        [Display(Name = "Organisation")]
        Organisation = 2
    }
}
