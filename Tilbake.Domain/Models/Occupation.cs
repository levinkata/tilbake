using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class Occupation
    {
        public Guid ID { get; set; }

        [Display(Name = "Occupation"), Required, StringLength(50)]
        public string Name { get; set; }
    }
}
