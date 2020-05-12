using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class PremiumType
    {
        public Guid ID { get; set; }

        [Display(Name = "Premium Type"), Required, StringLength(50)]
        public string Name { get; set; }
    }

}