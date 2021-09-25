using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class RatingMotorExcess
    {
        public RatingMotorExcess()
        {
            PortfolioRatingMotorExcesses = new HashSet<PortfolioRatingMotorExcess>();
        }

        public Guid Id { get; set; }
        public Guid InsurerId { get; set; }
        public decimal StartValue { get; set; }
        public decimal EndValue { get; set; }
        public string RateLocal { get; set; }
        public string RateImport { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Insurer Insurer { get; set; }
        public virtual ICollection<PortfolioRatingMotorExcess> PortfolioRatingMotorExcesses { get; set; }
    }
}
