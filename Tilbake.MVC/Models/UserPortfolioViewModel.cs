using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class UserPortfolioViewModel
    {
        public string UserId { get; set; }

        [Display(Name = "Portfolios")]
        public string[] PortfolioIds { get; set; }

        [Display(Name = "Assigned Portfolios")]
        public string[] AssignedPortfolios { get; set; }

        [Display(Name = "Available Portfolios")]
        public string[] UnAssignedPortfolios { get; set; }

        public SelectList Users { get; set; }
        public MultiSelectList PortfolioList { get; set; }
        public MultiSelectList UserPortfolioList { get; set; }
    }
}
