using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class City
    {
        public Guid ID { get; set; }

        [Display(Name = "City"), Required, StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Country")]
        public Guid LandID { get; set; }

        public virtual Land Land { get; private set; }
    }
}
