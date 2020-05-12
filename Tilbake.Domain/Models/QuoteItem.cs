using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.Domain.Models
{
    public class QuoteItem
    {
        public Guid ID { get; set; }
        public Guid QuoteID { get; set; }
        public Guid KlientRiskID { get; set; }

        [Display(Name = "Insurer")]
        public Guid InsurerID { get; set; }

        [Display(Name = "Cover Type")]
        public Guid CoverTypeID { get; set; }

        [Display(Name = "Sum Insured"), Column(TypeName = "decimal(18,2)")]
        public decimal SumInsured { get; set; }

        [Display(Name = "Premium"), Column(TypeName = "decimal(18,2)")]
        public decimal Premium { get; set; }

        [Display(Name = "Excess"), Required, StringLength(50)]
        public string Excess { get; set; }

        public virtual KlientRisk KlientRisk { get; private set; }
        public virtual CoverType CoverType { get; private set; }
        public virtual Insurer Insurer { get; private set; }
        public virtual Quote Quote { get; private set; }
    }
}
