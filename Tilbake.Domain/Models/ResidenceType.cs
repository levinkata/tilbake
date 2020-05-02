using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class ResidenceType
    {
        public Guid ID { get; set; }

        [Display(Name = "Residence Type"), Required, StringLength(50)]
        public string Name { get; set; }
    }
}
