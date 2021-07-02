﻿using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Resources
{
    public class BaseSaveResource
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Name"), MaxLength(50)]
        public string Name { get; set; }
    }
}