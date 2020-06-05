using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class KlientDocument
    {
        public Guid ID { get; set; }
        public Guid KlientID { get; set; }

        [Display(Name = "Description"), Required, StringLength(150)]
        public string Description { get; set; }        

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "Document Date")]
        public DateTime DocumentDate { get; set; }

        [Display(Name = "Document Type")]
        public Guid DocumentTypeID { get; set; }

        [Display(Name = "Document")]
        private readonly List<byte> document = new List<byte>();
        public List<byte> Document { get { return document; } }

        public virtual Klient Klient { get; private set; }
        public virtual DocumentType DocumentType { get; private set; }  
    }
}
