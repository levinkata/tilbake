using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class Incident
    {
        public Guid ID { get; set; }

        [Display(Name = "Incident"), Required, StringLength(50)]
        public string Name { get; set; }
    }

}