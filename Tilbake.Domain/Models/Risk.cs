using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public class Risk
    {
        public Guid ID { get; set; }
        public Guid? AllRiskID { get; set; }        
        public Guid? ContentID { get; set; }
        public Guid? GlassID { get; set; }
        public Guid? HouseID { get; set; }
        public Guid? MotorID { get; set; }

        public virtual AllRisk AllRisk { get; private set; }
        public virtual Content Content { get; private set; }
        public virtual Glass Glass { get; private set; }
        public virtual House House { get; private set; }
        public virtual Motor Motor { get; private set; }

        public virtual IReadOnlyCollection<KlientRisk> KlientRisks { get; set; } = new HashSet<KlientRisk>();
    }

}