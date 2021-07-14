using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class Motor
    {
        public Motor()
        {
            MotorImprovements = new HashSet<MotorImprovement>();
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
        public string Colour { get; set; }
        public Guid MotorUseId { get; set; }
        public bool GreyImport { get; set; }
        public bool SecurityFitting { get; set; }
        public bool TrackingDevice { get; set; }
        public bool Immobiliser { get; set; }
        public bool Alarm { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual BodyType BodyType { get; set; }
        public virtual DriverType DriverType { get; set; }
        public virtual MotorModel MotorModel { get; set; }
        public virtual MotorUse MotorUse { get; set; }
        public virtual ICollection<MotorImprovement> MotorImprovements { get; set; }
        public virtual ICollection<Risk> Risks { get; set; }
    }
}
