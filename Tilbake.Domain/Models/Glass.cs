﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class Glass
    {
        public Guid ID { get; set; }

        [Display(Name = "Component")]
        public Guid ComponentID { get; set; }

        public virtual RiskItem Component { get; private set; }
        public virtual IReadOnlyCollection<Risk> Risks { get; set; } = new HashSet<Risk>();
    }
}
