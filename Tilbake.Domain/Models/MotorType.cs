using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class MotorType
    {
        public Guid ID { get; set; }

        [Display(Name = "Motor Type"), Required, StringLength(50)]
        public string Name { get; set; }
    }
}
