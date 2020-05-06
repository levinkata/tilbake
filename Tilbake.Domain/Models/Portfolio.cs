using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class Portfolio
    {
        public Guid ID { get; set; }

        [Display(Name = "Portfolio"), Required, StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public virtual IReadOnlyCollection<PortfolioKlient> PortfolioKlients { get; set; } = new HashSet<PortfolioKlient>();
    }
}
