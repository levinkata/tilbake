using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Tilbake.MVC.Models
{
    public class FormFileViewModel
    {
        public IFormFile File { get; set; }
    }
}