using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class OccupationsViewModel
    {
        public IEnumerable<Occupation> Occupations { get; set; }
    }
}
