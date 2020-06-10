using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class DocumentCategory
    {
        public Guid ID { get; set; }

        [Display(Name = "Document Category"), Required, StringLength(50)]
        public string Name { get; set; }
    }
}
