using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class Building
    {
        public Building()
        {
            Risks = new HashSet<Risk>();
        }

        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; }
        public Guid ResidenceTypeId { get; set; }
        public Guid ResidenceUseId { get; set; }
        public Guid RoofTypeId { get; set; }
        public Guid WallTypeId { get; set; }
        public Guid BuildingConditionId { get; set; }
        public bool IsBurglarAlarm { get; set; }
        public bool IsBurglarBars { get; set; }
        public bool IsRentedOut { get; set; }
        public bool IsUnoccupied { get; set; }
        public string UnoccupancyPeriod { get; set; }
        public bool IsUseHouseSitters { get; set; }
        public bool IsKeepDogs { get; set; }
        public bool IsSecurityGates { get; set; }
        public bool IsArmedResponse { get; set; }
        public string ArmedResponseName { get; set; }
        public bool IsElectronicGate { get; set; }
        public bool IsElectricFence { get; set; }
        public bool IsSecurityComplex { get; set; }
        public bool IsRetirementVillage { get; set; }
        public bool IsAdjacentOpenArea { get; set; }
        public string BondHolder { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual BuildingCondition BuildingCondition { get; set; }
        public virtual ResidenceType ResidenceType { get; set; }
        public virtual ResidenceUse ResidenceUse { get; set; }
        public virtual RoofType RoofType { get; set; }
        public virtual WallType WallType { get; set; }
        public virtual ICollection<Risk> Risks { get; set; }
    }
}
