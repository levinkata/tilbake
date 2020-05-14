using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class RegionsViewModel
    {
        public IEnumerable<Region> Regions { get; set; }
    }
}