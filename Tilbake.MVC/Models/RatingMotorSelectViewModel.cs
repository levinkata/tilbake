using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class RatingMotorSelectViewModel
    {
        [Display(Name = "Insurer")]
        public Guid InsurerId { get; set; }

        public SelectList InsurerList { get; set; }
    }
}