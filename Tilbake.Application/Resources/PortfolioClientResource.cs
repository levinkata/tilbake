using System;
using System.ComponentModel.DataAnnotations;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Resources
{
    public class PortfolioClientResource
    {
        public Guid Id { get; set; }

        [Display(Name = "Portfolio")]
        public Guid PortfolioId { get; set; }

        [Display(Name = "Client")]
        public Guid ClientId { get; set; }

        [Display(Name = "Client Status")]
        public Guid ClientStatusId { get; set; }

        [Display(Name = "Withdrawal")]
        public bool IsWithdrawal { get; set; }

        public virtual Client Client { get; set; }
        public virtual ClientStatus ClientStatus { get; set; }
        public virtual Portfolio Portfolio { get; set; }        
    }
}