using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class FileFormatResource
    {
        public int Id { get; set; }

        [Display(Name = "File Format")]
        public string Name { get; set; }
    }
}
