using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class FileFormatViewModel
    {
        public int Id { get; set; }

        [Display(Name = "File Format")]
        public string Name { get; set; }
    }
}
