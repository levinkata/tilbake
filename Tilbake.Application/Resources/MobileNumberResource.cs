﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.Application.Resources
{
    public class MobileNumberResource
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }

        [Display(Name = "Mobile")]                
        public string Name { get; set; }

        [Display(Name = "Is Primary?")]                
        public bool IsPrimary { get; set; }
    }
}
