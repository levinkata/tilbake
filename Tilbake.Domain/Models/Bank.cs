using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Domain.Models
{
    public class Bank
    {
        public Guid ID { get; set; }

        [Display(Name = "Bank"), Required, StringLength(50)]
        public string Name { get; set; }
    }
}
