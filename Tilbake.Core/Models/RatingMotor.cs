using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class RatingMotor
    {
        public RatingMotor()
        {
            PortfolioRatingMotors = new HashSet<PortfolioRatingMotor>();
        }

        public Guid Id { get; set; }
        public Guid InsurerId { get; set; }
        public decimal StartValue { get; set; }
        public decimal EndValue { get; set; }
        public decimal RateLocal { get; set; }
        public decimal RateImport { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Insurer Insurer { get; set; }
        public virtual ICollection<PortfolioRatingMotor> PortfolioRatingMotors { get; set; }
    }
}
