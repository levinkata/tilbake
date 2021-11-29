using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class MotorModel
    {
        public MotorModel()
        {
            Motors = new HashSet<Motor>();
        }

        public Guid Id { get; set; }
        public Guid MotorMakeId { get; set; }
        public string Name { get; set; } = null!;
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual MotorMake MotorMake { get; set; } = null!;
        public virtual ICollection<Motor> Motors { get; set; }
    }
}
