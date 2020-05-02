using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class DriverType
    {
        public Guid ID { get; set; }

        [Display(Name = "Driver Type"), Required, StringLength(50)]
        public string Name { get; set; }
    }
}
