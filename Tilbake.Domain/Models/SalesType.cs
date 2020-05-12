using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class SalesType
    {
        public Guid ID { get; set; }

        [Display(Name = "Sales Type"), Required, StringLength(50)]
        public string Name { get; set; }
    }

}