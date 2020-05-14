using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class WallTypesViewModel
    {
        public IEnumerable<WallType> WallTypes { get; set; }
    }
}