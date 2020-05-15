using System;
using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class HousesViewModel
    {
        public Guid KlientID { get; set; }
        public IEnumerable<House> Houses { get; set; }
    }
}
