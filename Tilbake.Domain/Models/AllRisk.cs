using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class AllRisk
    {
        public Guid ID { get; set; }

        [Display(Name = "Description")]
        public Guid RiskItemID { get; set; }

        public virtual RiskItem RiskItem { get; private set; }
        public virtual IReadOnlyCollection<Risk> Risks { get; set; } = new HashSet<Risk>();
    }
}
