using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class RatingMotorSelectResource
    {
        [Display(Name = "Insurer")]
        public Guid InsurerId { get; set; }

        public SelectList InsurerList { get; set; }
    }
}