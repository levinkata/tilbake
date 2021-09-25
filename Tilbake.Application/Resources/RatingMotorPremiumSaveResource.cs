using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.Application.Resources
{
    public class RatingMotorPremiumSaveResource
    {
        public Guid InsurerId { get; set; }

        [Display(Name = "Minimum Monthly")]
        public decimal MinimumMonthly { get; set; }

        [Display(Name = "Minimum Annual")]
        public decimal MinimumAnnual { get; set; }

        [Display(Name = "Minimum Annual Third Paty")]        
        public decimal MinimumAnnualThirdParty { get; set; }
    }
}
