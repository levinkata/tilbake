using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class RiskItemViewModel
    {
        public Guid Id { get; set; }

        [Display(Description = "Name")]
        public string Description { get; set; }
    }
}