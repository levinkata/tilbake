using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Application.Resources
{
    public class RatingMotorResource
    {
        public Guid Id { get; set; }
        public Guid InsurerId { get; set; }

        [Display(Name = "From")]
        public decimal StartValue { get; set; }

        [Display(Name = "To")]
        public decimal EndValue { get; set; }

        [Display(Name = "Rate (Local)")]
        public decimal RateLocal { get; set; }

        [Display(Name = "Rate (Import)")]
        public decimal RateImport { get; set; }

        //  Tables
        public Insurer Insurer { get; set; }
    }
}
