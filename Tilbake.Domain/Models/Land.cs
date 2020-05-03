using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class Land
    {
        public Guid ID { get; set; }

        [Display(Name = "Country"), Required, StringLength(50)]
        public string Name { get; set; }
    }
}
