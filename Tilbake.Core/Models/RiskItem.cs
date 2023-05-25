using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class RiskItem
{
    public Guid Id { get; set; }

    public string Description { get; set; } = null!;

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<AllRiskSpecified> AllRiskSpecifieds { get; set; } = new List<AllRiskSpecified>();

    public virtual ICollection<AllRisk> AllRisks { get; set; } = new List<AllRisk>();

    public virtual ICollection<ElectronicEquipment> ElectronicEquipments { get; set; } = new List<ElectronicEquipment>();

    public virtual ICollection<Glass> Glasses { get; set; } = new List<Glass>();

    public virtual ICollection<Life> Lives { get; set; } = new List<Life>();

    public virtual ICollection<PublicLiability> PublicLiabilities { get; set; } = new List<PublicLiability>();

    public virtual ICollection<StatedBenefit> StatedBenefits { get; set; } = new List<StatedBenefit>();

    public virtual ICollection<WorkmanCompensation> WorkmanCompensations { get; set; } = new List<WorkmanCompensation>();
}
