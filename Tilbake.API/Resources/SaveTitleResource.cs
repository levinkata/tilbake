using System.ComponentModel.DataAnnotations;

namespace Tilbake.API.Resources
{
    public class SaveTitleResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
