using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class PortfolioClientResource
    {
        public Guid Id { get; set; }

        [Display(Name = "Portfolio")]
        public Guid PortfolioId { get; set; }

        [Display(Name = "Client")]
        public Guid ClientId { get; set; }

        [Display(Name = "Withdrawal")]
        public bool IsWithdrawal { get; set; }


    }
}