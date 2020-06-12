using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Tilbake.Domain.Models
{
    public class KlientDocument
    {
        public Guid ID { get; set; }
        public Guid KlientID { get; set; }

        [Display(Name = "Description"), StringLength(50)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "Document Date")]
        public DateTime DocumentDate { get; set; }

        [Display(Name = "Document Category")]
        public Guid DocumentCategoryID { get; set; }

        [Display(Name = "Photo")]
        //private readonly List<byte> image = new List<byte>();
        //public List<byte> Image { get { return image; } }

        public byte[] Photo { get; set; }

        public virtual Klient Klient { get; private set; }
        public virtual DocumentCategory DocumentCategory { get; private set; }
    }
}
