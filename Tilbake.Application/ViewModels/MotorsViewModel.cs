using System;
using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class MotorsViewModel
    {
        public Guid KlientID { get; set; }
        public IEnumerable<Motor> Motors { get; set; }
    }
}
