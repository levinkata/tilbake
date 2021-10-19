using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class MotorCycle
    {
        public MotorCycle()
        {
            Risks = new HashSet<Risk>();
        }

        public Guid Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public bool IsPrivateOrBusiness { get; set; }
        public bool IsAlarm { get; set; }
        public bool IsTrackingDevice { get; set; }
        public bool IsLockedInGarage { get; set; }
        public string FinancialInterest { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Risk> Risks { get; set; }
    }
}
