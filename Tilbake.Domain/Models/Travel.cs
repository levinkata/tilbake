﻿using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class Travel
    {
        public Travel()
        {
            Risks = new HashSet<Risk>();
            TravelBeneficiaries = new HashSet<TravelBeneficiary>();
        }

        public Guid Id { get; set; }
        public string PassportNumber { get; set; }
        public DateTime DepatureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Destination { get; set; }
        public string PersonVisited { get; set; }
        public string DoctorName { get; set; }
        public string DoctorContact { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Risk> Risks { get; set; }
        public virtual ICollection<TravelBeneficiary> TravelBeneficiaries { get; set; }
    }
}
