using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class MotorMake
    {
        public Guid ID { get; set; }

        [Display(Name = "Motor Make"), Required, StringLength(50)]
        public string Name { get; set; }

        public virtual IReadOnlyCollection<MotorModel> MotorModels { get; set; } = new HashSet<MotorModel>();
    }

}