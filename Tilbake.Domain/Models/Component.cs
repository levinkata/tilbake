using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class Component
    {
        public Guid ID { get; set; }

        [Display(Name = "Body Type"), Required, StringLength(50)]
        public string Name { get; set; }
    }
}
