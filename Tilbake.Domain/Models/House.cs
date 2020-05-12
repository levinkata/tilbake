using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class House
    {
        public Guid ID { get; set; }

        [Display(Name = "Location"), Required, StringLength(150)]
        public string Location { get; set; }

        [Display(Name = "Residence Type")]
        public Guid ResidenceTypeID { get; set; }

        [Display(Name = "Roof Type")]
        public Guid RoofTypeID { get; set; }

        [Display(Name = "Wall Type")]
        public Guid WallTypeID { get; set; }

        public virtual ResidenceType ResidenceType { get; private set; }
        public virtual RoofType RoofType { get; private set; }
        public virtual WallType WallType { get; private set; }
        public virtual IReadOnlyCollection<Risk> Risks{ get; set; } = new HashSet<Risk>();
    }
}
