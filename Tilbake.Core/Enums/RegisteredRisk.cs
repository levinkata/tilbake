using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.Core.Enums
{
    public enum RegisteredRisk
    {
        [Display(Name = "AllRisk")]
        AllRisk = 1,

        [Display(Name = "AllRiskSpecified")]
        AllRiskSpecified = 2,

        [Display(Name = "Building")]
        Building = 3,

        [Display(Name = "Content")]
        Content = 4,

        [Display(Name = "House")]
        House = 5,

        [Display(Name = "Motor")]
        Motor = 6,

        [Display(Name = "Travel")]
        Travel = 7
    }
}
