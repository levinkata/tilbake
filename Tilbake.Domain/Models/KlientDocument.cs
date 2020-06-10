using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class KlientDocument
    {
        public Guid ID { get; set; }
        public Guid KlientID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "Document Date")]
        public DateTime DocumentDate { get; set; }

        [Display(Name = "Document Category")]
        public Guid DocumentCategoryID { get; set; }

        [Display(Name = "Document")]
        private readonly List<byte> document = new List<byte>();
        public List<byte> Document { get { return document; } }

        public virtual Klient Klient { get; private set; }
        public virtual DocumentCategory DocumentCategory { get; private set; }
    }
}
