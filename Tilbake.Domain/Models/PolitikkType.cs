using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class PolitikkType
    {
        public Guid ID { get; set; }

        [Display(Name = "Policy Type"), Required, StringLength(50)]
        public string Name { get; set; }
    }

}