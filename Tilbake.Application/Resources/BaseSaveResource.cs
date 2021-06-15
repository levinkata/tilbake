using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class BaseSaveResource
    {
        [Required, StringLength(50)]
        public string Name { get; set; }        
    }
}