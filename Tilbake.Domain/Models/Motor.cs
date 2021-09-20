using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class Motor
    {
        public Motor()
        {
            MotorAccessories = new HashSet<MotorAccessory>();
            MotorImprovements = new HashSet<MotorImprovement>();
            MotorRadios = new HashSet<MotorRadio>();
            Risks = new HashSet<Risk>();
        }

        public Guid Id { get; set; }
        public string RegNumber { get; set; }
        public Guid BodyTypeId { get; set; }
        public Guid MotorModelId { get; set; }
        public int RegYear { get; set; }
        public Guid DriverTypeId { get; set; }
        public string EngineNumber { get; set; }
        public string ChassisNumber { get; set; }
        public string EngineCapacity { get; set; }
        public int OdometerReading { get; set; }
        public string Colour { get; set; }
        public Guid MotorUseId { get; set; }
        public bool IsImport { get; set; }
        public bool IsSecurityFitting { get; set; }
        public bool IsTrackingDevice { get; set; }
        public bool IsImmobiliser { get; set; }
        public bool IsImmobiliserFactoryFitted { get; set; }
        public bool IsAlarm { get; set; }
        public bool IsGearLock { get; set; }
        public int DaysOutOfCountry { get; set; }
        public string FinancialInterest { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual BodyType BodyType { get; set; }
        public virtual DriverType DriverType { get; set; }
        public virtual MotorModel MotorModel { get; set; }
        public virtual MotorUse MotorUse { get; set; }
        public virtual ICollection<MotorAccessory> MotorAccessories { get; set; }
        public virtual ICollection<MotorImprovement> MotorImprovements { get; set; }
        public virtual ICollection<MotorRadio> MotorRadios { get; set; }
        public virtual ICollection<Risk> Risks { get; set; }
    }
}
