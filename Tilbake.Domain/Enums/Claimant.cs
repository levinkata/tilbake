using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Enums
{
    public enum Claimant
    {
        [Display(Name = "Own Damage")]
        OwnDamage = 1,

        [Display(Name = "Third Party")]
        ThirdParty = 2,
    }
}
