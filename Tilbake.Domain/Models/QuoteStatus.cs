using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class QuoteStatus
    {
        public Guid ID { get; set; }

        [Display(Name = "Quote Status"), Required, StringLength(50)]
        public string Name { get; set; }
    }
}
