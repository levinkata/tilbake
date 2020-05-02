using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class CoverType
    {
        public Guid ID { get; set; }

        [Display(Name = "Cover Type"), Required, StringLength(50)]
        public string Name { get; set; }
    }
}
