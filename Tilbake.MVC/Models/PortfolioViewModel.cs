using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class PortfolioViewModel : BaseViewModel
    {
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Is Scheme?")]
        public bool IsScheme { get; set; }


        [Display(Name = "Customers")]
        public int TotalCustomers { get; set; }

        public string? UserId { get; set; }
    }
}