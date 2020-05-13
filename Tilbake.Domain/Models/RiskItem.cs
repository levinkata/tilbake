using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class RiskItem
    {
        public Guid ID { get; set; }

        [Display(Name = "Description"), Required, StringLength(50)]
        public string Description { get; set; }
    }
}
