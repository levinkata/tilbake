using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class Insurer
    {
        public Guid ID { get; set; }

        [Display(Name = "Insurer"), Required, StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Image")]
        private readonly List<byte> image = new List<byte>();
        public List<byte> Image { get { return image; } }
    }
}
