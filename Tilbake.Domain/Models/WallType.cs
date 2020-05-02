using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class WallType
    {
        public Guid ID { get; set; }

        [Display(Name = "Wall Type"), Required, StringLength(50)]
        public string Name { get; set; }
    }
}
