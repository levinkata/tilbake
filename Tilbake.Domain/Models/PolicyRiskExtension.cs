using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class PolicyRiskExtension
    {
        public Guid PolicyRiskId { get; set; }
        public Guid ExtensionId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Extension Extension { get; set; }
        public virtual PolicyRisk PolicyRisk { get; set; }
    }
}
