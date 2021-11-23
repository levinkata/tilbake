using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class ExcessBuyBackViewModel
    {
        public Guid Id { get; set; }
        public Guid PortfolioClientId { get; set; }
        public Guid QuoteItemId { get; set; }
        public Guid QuoteId { get; set; }
        public Guid PolicyRiskId { get; set; }
        public Guid ParentPolicyId { get; set; }

        [Display(Name = "Motor")]
        public Guid MotorId { get; set; }
        public Guid? ModifiedBy { get; set; }

        public MotorViewModel Motor { get; set; }
        public PolicyViewModel ParentPolicy { get; set; }
    }
}
