using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class RoofType
    {
        public Guid ID { get; set; }

        [Display(Name = "Roof Type"), Required, StringLength(50)]
        public string Name { get; set; }
    }
}
