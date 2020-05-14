using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class CoverTypesViewModel
    {
        public IEnumerable<CoverType> CoverTypes { get; set; }
    }
}
