using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class Requisition
    {
        public Requisition()
        {
            PayableRequisitions = new HashSet<PayableRequisition>();
        }

        public Guid Id { get; set; }
        public int RequisitionNumber { get; set; }
        public DateTime RequisitionDate { get; set; }
        public Guid RequestedById { get; set; }
        public int ClaimNumber { get; set; }
        public decimal Amount { get; set; }
        public decimal TaxableAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public Guid TaxId { get; set; }
        public decimal NewEstimateOd { get; set; }
        public decimal NewEstimateTp { get; set; }
        public bool IsClaimFinalised { get; set; }
        public Guid PayeeId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public Guid ChartOfAccountsId { get; set; }
        public Guid? AuthorisedById { get; set; }
        public DateTime? AuthorisedDate { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ChartOfAccount ChartOfAccounts { get; set; }
        public virtual Claim ClaimNumberNavigation { get; set; }
        public virtual Tax Tax { get; set; }
        public virtual ICollection<PayableRequisition> PayableRequisitions { get; set; }
    }
}
