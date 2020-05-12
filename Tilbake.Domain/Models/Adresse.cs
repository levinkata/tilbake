using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class Adresse
    {
        public Guid ID { get; set; }

        [Display(Name = "Physical Address"), Required, StringLength(100)]
        public string PhysicalAddress { get; set; }

        [Display(Name = "Postal Address"), Required, StringLength(50)]
        public string PostalAddress { get; set; }

        [Display(Name = "City")]
        public Guid CityID { get; set; }

        public virtual City City { get; private set; }
    }
}
