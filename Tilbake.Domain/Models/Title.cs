using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class Title
    {
        public Guid ID { get; set; }

        [Display(Name = "Title"), Required, StringLength(50)]
        public string Name { get; set; }
    }
}
