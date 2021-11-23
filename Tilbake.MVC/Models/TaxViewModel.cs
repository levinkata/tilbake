using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class TaxViewModel
    {
        public Guid Id { get; set; }

        [Display(Description = "Name")]
        public string Name { get; set; }

        [Display(Description = "Tax Rate")]
        public decimal TaxRate { get; set; }

        [Display(Description = "Tax Date")]
        public DateTime TaxDate { get; set; }
    }
}