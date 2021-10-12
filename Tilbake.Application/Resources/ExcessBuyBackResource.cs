using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class ExcessBuyBackResource
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

        public MotorResource Motor { get; set; }
        public PolicyResource ParentPolicy { get; set; }
    }
}
