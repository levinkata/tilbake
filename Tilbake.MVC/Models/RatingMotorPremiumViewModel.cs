using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.MVC.Models
{
    public class RatingMotorPremiumViewModel
    {
        public Guid Id { get; set; }
        public Guid InsurerId { get; set; }

        [Display(Name = "Minimum Monthly")]
        public decimal MinimumMonthly { get; set; }

        [Display(Name = "Minimum Annual")]
        public decimal MinimumAnnual { get; set; }

        [Display(Name = "Minimum Annual Third Paty")]        
        public decimal MinimumAnnualThirdParty { get; set; }
        
        //  Tables
        public Insurer Insurer { get; set; }
    }
}
