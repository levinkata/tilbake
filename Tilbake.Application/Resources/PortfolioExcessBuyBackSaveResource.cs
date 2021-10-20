using System;
using System.ComponentModel.DataAnnotations;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Resources
{
    public class PortfolioExcessBuyBackSaveResource
    {
        public Guid Id { get; set; }
        public Guid PortfolioId { get; set; }
        public Guid InsurerId { get; set; }

        [Display(Name = "Excess Rate")]
        public decimal ExcessRate { get; set; }

        [Display(Name = "BuyBack Rate")]
        public decimal BuyBackRate { get; set; }
    }
}