using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class Risk
    {
        public Risk()
        {
            ClientRisks = new HashSet<ClientRisk>();
        }

        public Guid Id { get; set; }
        public Guid? AllRiskId { get; set; }
        public Guid? ContentId { get; set; }
        public Guid? ElectronicEquipmentId { get; set; }
        public Guid? GlassId { get; set; }
        public Guid? HouseId { get; set; }
        public Guid? MotorId { get; set; }
        public Guid? PublicLiabilityId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual AllRisk AllRisk { get; set; }
        public virtual Content Content { get; set; }
        public virtual ElectronicEquipment ElectronicEquipment { get; set; }
        public virtual Glass Glass { get; set; }
        public virtual House House { get; set; }
        public virtual Motor Motor { get; set; }
        public virtual PublicLiability PublicLiability { get; set; }
        public virtual ICollection<ClientRisk> ClientRisks { get; set; }
    }
}
