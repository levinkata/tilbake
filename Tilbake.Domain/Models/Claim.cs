using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class Claim
    {
        public Claim()
        {
            ClaimAttorneys = new HashSet<ClaimAttorney>();
            ClaimDocuments = new HashSet<ClaimDocument>();
            ClaimLossAdjusters = new HashSet<ClaimLossAdjuster>();
            ClaimRepairers = new HashSet<ClaimRepairer>();
            ClaimRoadsideAssists = new HashSet<ClaimRoadsideAssist>();
            ClaimThirdParties = new HashSet<ClaimThirdParty>();
            ClaimTowTrucks = new HashSet<ClaimTowTruck>();
            ClaimTracingAgents = new HashSet<ClaimTracingAgent>();
            PolicyRiskClaims = new HashSet<PolicyRiskClaim>();
            PremiumRefundClaims = new HashSet<PremiumRefundClaim>();
            Requisitions = new HashSet<Requisition>();
            ValuationFeeRefundClaims = new HashSet<ValuationFeeRefundClaim>();
        }

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
        public string IncidentDetail { get; set; }
        public string Comment { get; set; }
        public Guid? AddedById { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ClaimStatus ClaimStatus { get; set; }
        public virtual Claimant Claimant { get; set; }
        public virtual Incident Incident { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<ClaimAttorney> ClaimAttorneys { get; set; }
        public virtual ICollection<ClaimDocument> ClaimDocuments { get; set; }
        public virtual ICollection<ClaimLossAdjuster> ClaimLossAdjusters { get; set; }
        public virtual ICollection<ClaimRepairer> ClaimRepairers { get; set; }
        public virtual ICollection<ClaimRoadsideAssist> ClaimRoadsideAssists { get; set; }
        public virtual ICollection<ClaimThirdParty> ClaimThirdParties { get; set; }
        public virtual ICollection<ClaimTowTruck> ClaimTowTrucks { get; set; }
        public virtual ICollection<ClaimTracingAgent> ClaimTracingAgents { get; set; }
        public virtual ICollection<PolicyRiskClaim> PolicyRiskClaims { get; set; }
        public virtual ICollection<PremiumRefundClaim> PremiumRefundClaims { get; set; }
        public virtual ICollection<Requisition> Requisitions { get; set; }
        public virtual ICollection<ValuationFeeRefundClaim> ValuationFeeRefundClaims { get; set; }
    }
}
