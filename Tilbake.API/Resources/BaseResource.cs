using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.API.Resources
{
    public class BaseResource
    {
        public Guid Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
