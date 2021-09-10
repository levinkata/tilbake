using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.Domain.Enums
{
    public enum IdDocument
    {
        [Display(Name = "Omang")]
        Omang = 1,
        
        [Display(Name = "Passport")]
        Passport = 2
    }
}
