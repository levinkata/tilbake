using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Application.Resources
{
    public class RatingMotorDiscountResource
    {
        public Guid Id { get; set; }
        public Guid InsurerId { get; set; }

        [Display(Name = "CFG")]
        public int ClaimFreeGroup { get; set; }

        [Display(Name = "Rate")]
        public decimal Rate { get; set; }

        //  Tables
        public Insurer Insurer { get; set; }
    }
}
