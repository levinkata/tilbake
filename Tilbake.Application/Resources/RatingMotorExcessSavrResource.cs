using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.Application.Resources
{
    public class RatingMotorExcessSaveResource
    {
        public Guid InsurerId { get; set; }

        [Display(Name = "From")]
        public decimal StartValue { get; set; }

        [Display(Name = "To")]
        public decimal EndValue { get; set; }

        [Display(Name = "Rate (Local)")]
        public string RateLocal { get; set; }

        [Display(Name = "Rate (Import)")]
        public string RateImport { get; set; }
    }
}
