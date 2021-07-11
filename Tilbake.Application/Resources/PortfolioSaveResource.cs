using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace Tilbake.Application.Resources
{
    public class PortfolioSaveResource : BaseSaveResource
    {
        [Required(ErrorMessage = "Please enter Description")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Is Scheme?")]
        public bool IsScheme { get; set; }
    }
}