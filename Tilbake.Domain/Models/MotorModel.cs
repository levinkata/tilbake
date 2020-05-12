using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class MotorModel
    {
        public Guid ID { get; set; }
        public Guid MakeID { get; set; }

        [Display(Name = "Motor Model"), Required, StringLength(50)]
        public string Name { get; set; }

        public virtual MotorMake MotorMake { get; private set; }
    }
}
