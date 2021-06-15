using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class RiskItem
    {
        public RiskItem()
        {
            AllRisks = new HashSet<AllRisk>();
            ElectronicEquipments = new HashSet<ElectronicEquipment>();
            Glasses = new HashSet<Glass>();
            PublicLiabilities = new HashSet<PublicLiability>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<AllRisk> AllRisks { get; set; }
        public virtual ICollection<ElectronicEquipment> ElectronicEquipments { get; set; }
        public virtual ICollection<Glass> Glasses { get; set; }
        public virtual ICollection<PublicLiability> PublicLiabilities { get; set; }
    }
}
