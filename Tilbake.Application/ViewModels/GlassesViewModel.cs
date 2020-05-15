using System;
using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class GlassesViewModel
    {
        public Guid KlientID { get; set; }
        public IEnumerable<Glass> Glasses { get; set; }
    }
}
