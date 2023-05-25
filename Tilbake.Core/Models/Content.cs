using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Content
{
    public Guid Id { get; set; }

    public string PhysicalAddress { get; set; } = null!;

    public Guid ResidenceTypeId { get; set; }

    public Guid ResidenceUseId { get; set; }

    public Guid RoofTypeId { get; set; }

    public Guid WallTypeId { get; set; }

    public Guid BuildingConditionId { get; set; }

    public bool IsBurglarAlarm { get; set; }

    public bool IsBurglarBars { get; set; }

    public bool IsRentedOut { get; set; }

    public bool IsUnoccupied { get; set; }

    public string? UnoccupancyPeriod { get; set; }

    public bool IsUseHouseSitters { get; set; }

    public bool IsKeepDogs { get; set; }

    public bool IsSecurityGates { get; set; }

    public bool IsArmedResponse { get; set; }

    public string? ArmedResponseName { get; set; }

    public bool IsElectronicGate { get; set; }

    public bool IsElectricFence { get; set; }

    public bool IsSecurityComplex { get; set; }

    public bool IsRetirementVillage { get; set; }

    public bool IsAdjacentOpenArea { get; set; }

    public string? BondHolder { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual BuildingCondition BuildingCondition { get; set; } = null!;

    public virtual ResidenceType ResidenceType { get; set; } = null!;

    public virtual ResidenceUse ResidenceUse { get; set; } = null!;

    public virtual ICollection<Risk> Risks { get; set; } = new List<Risk>();

    public virtual RoofType RoofType { get; set; } = null!;

    public virtual WallType WallType { get; set; } = null!;
}
