using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.Domain.Models
{
    public class InvoiceItem
    {
        public Guid ID { get; set; }
        public Guid InvoiceID { get; set; }
        public Guid PolitikkRiskID { get; set; }

        public virtual PolitikkRisk PolitikkRisk { get; private set; }
        public virtual Invoice Invoice { get; private set; }
    }
}
