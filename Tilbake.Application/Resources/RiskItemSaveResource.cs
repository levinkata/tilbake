using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class RiskItemSaveResource
    {
        [Display(Description = "Name")]
        public string Description { get; set; }
    }
}