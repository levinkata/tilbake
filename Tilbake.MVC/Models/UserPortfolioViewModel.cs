using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class UserPortfolioViewModel
    {
        public string UserId { get; set; }

        [Display(Name = "Portfolios")]
        public Guid[] PortfolioIds { get; set; }

        [Display(Name = "Assigned Portfolios")]
        public Guid[] AssignedPortfolios { get; set; }

        [Display(Name = "Available Portfolios")]
        public Guid[] UnAssignedPortfolios { get; set; }

        public SelectList? Users { get; set; }
        public MultiSelectList? PortfolioList { get; set; }
        public MultiSelectList? UserPortfolioList { get; set; }
    }
}
