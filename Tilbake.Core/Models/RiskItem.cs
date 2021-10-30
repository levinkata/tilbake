using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class RiskItem
    {
        public RiskItem()
        {
            AllRiskSpecifieds = new HashSet<AllRiskSpecified>();
            AllRisks = new HashSet<AllRisk>();
            ElectronicEquipments = new HashSet<ElectronicEquipment>();
            Glasses = new HashSet<Glass>();
            Lives = new HashSet<Life>();
            PublicLiabilities = new HashSet<PublicLiability>();
            StatedBenefits = new HashSet<StatedBenefit>();
            WorkmanCompensations = new HashSet<WorkmanCompensation>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<AllRiskSpecified> AllRiskSpecifieds { get; set; }
        public virtual ICollection<AllRisk> AllRisks { get; set; }
        public virtual ICollection<ElectronicEquipment> ElectronicEquipments { get; set; }
        public virtual ICollection<Glass> Glasses { get; set; }
        public virtual ICollection<Life> Lives { get; set; }
        public virtual ICollection<PublicLiability> PublicLiabilities { get; set; }
        public virtual ICollection<StatedBenefit> StatedBenefits { get; set; }
        public virtual ICollection<WorkmanCompensation> WorkmanCompensations { get; set; }
    }
}
