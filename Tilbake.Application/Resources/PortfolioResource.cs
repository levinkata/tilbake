using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class PortfolioResource : BaseResource
    {
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Is Scheme?")]
        public bool IsScheme { get; set; }


        [Display(Name = "Clients")]
        public int TotalClients { get; set; }

        public string UserId { get; set; }
    }
}