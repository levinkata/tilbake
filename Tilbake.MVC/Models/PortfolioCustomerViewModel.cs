using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class PortfolioCustomerViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Portfolio")]
        public Guid PortfolioId { get; set; }

        [Display(Name = "Customer")]
        public Guid CustomerId { get; set; }

        [Display(Name = "Customer Status")]
        public Guid CustomerStatusId { get; set; }

        [Display(Name = "Withdrawal")]
        public bool IsWithdrawal { get; set; }

        //public AddressViewModel? Address { get; set; }
        public virtual CustomerViewModel? Customer { get; set; }
        public virtual CustomerStatusViewModel? CustomerStatus { get; set; }
        public virtual PortfolioViewModel? Portfolio { get; set; }

        public SelectList? CustomerStatusList { get; set; }


    }
}
