using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class BaseSaveResource
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Name"), MaxLength(50)]
        public string Name { get; set; }

        public Guid? AddedBy { get; set; }
    }
}
