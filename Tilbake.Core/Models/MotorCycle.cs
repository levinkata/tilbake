using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class MotorCycle
{
    public Guid Id { get; set; }

    public string RegistrationNumber { get; set; } = null!;

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public bool IsPrivateOrBusiness { get; set; }

    public bool IsAlarm { get; set; }

    public bool IsTrackingDevice { get; set; }

    public bool IsLockedInGarage { get; set; }

    public string? FinancialInterest { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<Risk> Risks { get; set; } = new List<Risk>();
}
