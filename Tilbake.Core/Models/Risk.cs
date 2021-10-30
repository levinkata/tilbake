using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class Risk
    {
        public Risk()
        {
            ClientRisks = new HashSet<ClientRisk>();
        }

        public Guid Id { get; set; }
        public Guid? AllRiskId { get; set; }
        public Guid? AllRiskSpecifiedId { get; set; }
        public Guid? BuildingId { get; set; }
        public Guid? ContentId { get; set; }
        public Guid? ElectronicEquipmentId { get; set; }
        public Guid? GlassId { get; set; }
        public Guid? HouseId { get; set; }
        public Guid? LifeId { get; set; }
        public Guid? MotorId { get; set; }
        public Guid? ExcessBuyBackId { get; set; }
        public Guid? MotorCycleId { get; set; }
        public Guid? PublicLiabilityId { get; set; }
        public Guid? StatedBenefitId { get; set; }
        public Guid? TrailerId { get; set; }
        public Guid? TravelId { get; set; }
        public Guid? WorkmanCompensationId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual AllRisk AllRisk { get; set; }
        public virtual AllRiskSpecified AllRiskSpecified { get; set; }
        public virtual Building Building { get; set; }
        public virtual Content Content { get; set; }
        public virtual ElectronicEquipment ElectronicEquipment { get; set; }
        public virtual ExcessBuyBack ExcessBuyBack { get; set; }
        public virtual Glass Glass { get; set; }
        public virtual House House { get; set; }
        public virtual Life Life { get; set; }
        public virtual Motor Motor { get; set; }
        public virtual MotorCycle MotorCycle { get; set; }
        public virtual PublicLiability PublicLiability { get; set; }
        public virtual StatedBenefit StatedBenefit { get; set; }
        public virtual Trailer Trailer { get; set; }
        public virtual Travel Travel { get; set; }
        public virtual WorkmanCompensation WorkmanCompensation { get; set; }
        public virtual ICollection<ClientRisk> ClientRisks { get; set; }
    }
}
