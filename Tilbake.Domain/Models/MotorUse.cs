using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class MotorUse
    {
        public Guid ID { get; set; }

        [Display(Name = "Motor Use"), Required, StringLength(50)]
        public string Name { get; set; }
    }

}