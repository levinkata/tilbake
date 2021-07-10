using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class AspnetUserPortfolioResource
    {
        public string AspNetUserId { get; set; }
        public Guid PortfolioId { get; set; }

        //  Descriptions

        [Display(Name = "Portfolio")]
        public string PortfolioName { get; set; }
    }
}
