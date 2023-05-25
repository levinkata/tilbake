using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class MotorImprovement
{
    public Guid Id { get; set; }

    public Guid MotorId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool FactoryFitted { get; set; }

    public string MakeModel { get; set; } = null!;

    public string SerialNumber { get; set; } = null!;

    public DateTime PurchaseDate { get; set; }

    public decimal Value { get; set; }

    public decimal Premium { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Motor Motor { get; set; } = null!;
}
