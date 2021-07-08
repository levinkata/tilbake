using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class PortfolioClientSaveResource
    {
        [Display(Name = "Portfolio")]
        public Guid PortfolioId { get; set; }

        [Display(Name = "Client")]
        public Guid ClientId { get; set; }

        [Display(Name = "Withdrawal")]
        public bool IsWithdrawal { get; set; }

    }
}