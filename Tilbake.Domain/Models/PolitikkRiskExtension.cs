using System;

namespace Tilbake.Domain.Models
{
    public class PolitikkRiskExtension
    {
        public Guid PolitikkRiskID { get; set; }
        public Guid ExtensionID { get; set; }

        public virtual PolitikkRisk PolitikkRisk { get; private set; }
        public virtual Extension Extension { get; private set; }
    }
}
