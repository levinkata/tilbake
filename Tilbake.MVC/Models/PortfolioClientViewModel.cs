using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class PortfolioClientViewModel
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

        //public AddressViewModel? Address { get; set; }
        public virtual ClientViewModel? Client { get; set; }
        public virtual ClientStatusViewModel? ClientStatus { get; set; }
        public virtual PortfolioViewModel? Portfolio { get; set; }

        public SelectList? ClientStatusList { get; set; }


    }
}
