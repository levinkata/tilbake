using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class AspnetUserPortfolioViewModel
    {
        public string AspNetUserId { get; set; }
        public Guid PortfolioId { get; set; }

        //  Descriptions

        [Display(Name = "Portfolio")]
        public string PortfolioName { get; set; }
    }
}
