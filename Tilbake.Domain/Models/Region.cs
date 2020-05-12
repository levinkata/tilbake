using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class Region
    {
        public Guid ID { get; set; }

        [Display(Name = "Region"), Required, StringLength(50)]
        public string Name { get; set; }
    }

}