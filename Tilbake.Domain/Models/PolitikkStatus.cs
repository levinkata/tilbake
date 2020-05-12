using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class PolitikkStatus
    {
        public Guid ID { get; set; }

        [Display(Name = "Policy Status"), Required, StringLength(50)]
        public string Name { get; set; }
    }

}