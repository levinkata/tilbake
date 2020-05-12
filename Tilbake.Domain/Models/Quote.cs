using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class Quote
    {
        public Guid ID { get; set; }

        [Display(Name = "Quote Number"), Required, StringLength(50)]
        public int QuoteNumber { get; set; }

        [Display(Name = "Quote Date"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = true)]
        public DateTime QuoteDate { get; set; }

        [Display(Name = "Quote Status")]
        public Guid QuoteStatusID { get; set; }

        [Display(Name = "Client Info"), StringLength(150)]
        public string KlientInfo { get; set; }

        [Display(Name = "Internal Info"), StringLength(150)]
        public string InternalInfo { get; set; }

        public virtual QuoteStatus QuoteStatus { get; private set; }
        public virtual IReadOnlyCollection<QuoteItem> QuoteItems { get; set; } = new HashSet<QuoteItem>();
    }
}
