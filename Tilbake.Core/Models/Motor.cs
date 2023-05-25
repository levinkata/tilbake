using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Motor
{
    public Guid Id { get; set; }

    public string RegNumber { get; set; } = null!;

    public Guid BodyTypeId { get; set; }

    public Guid MotorModelId { get; set; }

    public int RegYear { get; set; }

    public Guid DriverTypeId { get; set; }

    public string EngineNumber { get; set; } = null!;

    public string ChassisNumber { get; set; } = null!;

    public string EngineCapacity { get; set; } = null!;

    public int OdometerReading { get; set; }

    public int ClaimFreeGroup { get; set; }

    public string Colour { get; set; } = null!;

    public bool IsPrivateOrBusiness { get; set; }

    public bool IsImport { get; set; }

    public bool IsTrackingDevice { get; set; }

    public string? TrackingDevice { get; set; }

    public bool IsImmobiliser { get; set; }

    public bool IsImmobiliserFactoryFitted { get; set; }

    public bool IsAlarm { get; set; }

    public bool IsGearLock { get; set; }

    public bool IsParkedLockedGarage { get; set; }

    public bool IsParkedStreet { get; set; }

    public string? OtherParked { get; set; }

    public bool IsSoftRoofTop { get; set; }

    public bool IsExcessBuyBack { get; set; }

    public int DaysOutOfCountry { get; set; }

    public string? RegisteredOwner { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual BodyType BodyType { get; set; } = null!;

    public virtual DriverType DriverType { get; set; } = null!;

    public virtual ICollection<ExcessBuyBack> ExcessBuyBacks { get; set; } = new List<ExcessBuyBack>();

    public virtual ICollection<MotorAccessory> MotorAccessories { get; set; } = new List<MotorAccessory>();

    public virtual ICollection<MotorDriver> MotorDrivers { get; set; } = new List<MotorDriver>();

    public virtual ICollection<MotorImprovement> MotorImprovements { get; set; } = new List<MotorImprovement>();

    public virtual MotorModel MotorModel { get; set; } = null!;

    public virtual ICollection<MotorRadio> MotorRadios { get; set; } = new List<MotorRadio>();

    public virtual ICollection<Risk> Risks { get; set; } = new List<Risk>();
}
