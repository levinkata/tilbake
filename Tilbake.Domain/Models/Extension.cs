using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class Extension
    {
        public Guid ID { get; set; }

        [Display(Name = "Extension"), Required, StringLength(50)]
        public string Name { get; set; }
    }
}
