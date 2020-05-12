using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.Domain.Models
{
    public class Motor
    {
        public Guid ID { get; set; }

        [Display(Name = "Registrion Number"), Required, StringLength(50)]
        public string RegNumber { get; set; }

        [Display(Name = "Body Type")]
        public Guid BodyTypeID { get; set; }

        [Display(Name = "Make")]
        public Guid MotorMakeID { get; set; }

        [Display(Name = "Model")]
        public Guid MotorModeID { get; set; }

        [Display(Name = "Year")]
        public int RegYear { get; set; }

        [Display(Name = "Driver Type")]
        public Guid DriverTypeID { get; set; }

        [Display(Name = "Engine Number"), Required, StringLength(50)]
        public string EngineNumber { get; set; }

        [Display(Name = "Chassis Number"), Required, StringLength(50)]
        public string ChassisNumber { get; set; }

        [Display(Name = "Engine Capacity"), Required, StringLength(50)]
        public string EngineCapacity { get; set; }

        [Display(Name = "Colour"), Required, StringLength(50)]
        public string Colour { get; set; }

        [Display(Name = "Motor Use")]
        public Guid MotorUseID { get; set; }

        [Display(Name = "Security Fitting")]
        public bool SecurityFitting { get; set; }

        public virtual BodyType BodyType { get; private set; }
        public virtual MotorMake MotorMake { get; private set; }
        public virtual DriverType DriverType { get; private set; }
        public virtual MotorUse MotorUse { get; private set; }
        public virtual IReadOnlyCollection<MotorImprovement> MotorImprovements { get; set; } = new HashSet<MotorImprovement>();
        public virtual IReadOnlyCollection<Risk> Risks { get; set; } = new HashSet<Risk>();
    }
}
