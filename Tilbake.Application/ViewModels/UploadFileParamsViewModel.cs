using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.ViewModels
{
    public class UploadFileParamsViewModel
    {
        public Guid KlientID { get; set; }

        [Display(Name = "Description"), Required, StringLength(50)]
        public string Description { get; set; }
        public Guid DocumentTypeID { get; set; }
    }
}
