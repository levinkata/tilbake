using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tilbake.Domain.Models
{
    public class Premium
    {
        public Guid ID { get; set; }

        [Display(Name = "Policy")]
        public Guid PolitikkID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "Premium Date")]
        public DateTime PremiumDate { get; set; }

        [Display(Name = "Month"), Range(1, 12)]
        public int PremiumMonth { get; set; }

        [Display(Name = "Year"), Range(1900, 2099)]
        public int PremiumYear { get; set; }

        [Display(Name = "Premium"), Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Display(Name = "Premium Type")]
        public Guid PremiumTypeID { get; set; }

        public virtual Politikk Politikk { get; private set; }
        public virtual PremiumType PremiumType { get; private set; }
    }
}
