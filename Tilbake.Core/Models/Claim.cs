using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class Claim
    {
        public Guid Id { get; set; }
        public int ClaimNumber { get; set; }
        public Guid ClaimantId { get; set; }
        public DateTime ReportDate { get; set; }
        public DateTime IncidentDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public decimal EstimateOd { get; set; }
        public decimal EstimateTp { get; set; }
        public decimal RevisedEstimateOd { get; set; }
        public decimal RevisedEstimateTp { get; set; }
        public decimal Excess { get; set; }
        public bool IsThirdPartyRecover { get; set; }
        public Guid IncidentId { get; set; }
        public Guid RegionId { get; set; }
        public int ClaimFlag { get; set; }
        public Guid ClaimStatusId { get; set; }
        public string? IncidentDetail { get; set; }
        public string? Comment { get; set; }
        public Guid? AddedById { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ClaimStatus ClaimStatus { get; set; } = null!;
        public virtual Claimant Claimant { get; set; } = null!;
        public virtual Incident Incident { get; set; } = null!;
        public virtual Region Region { get; set; } = null!;
    }
}
