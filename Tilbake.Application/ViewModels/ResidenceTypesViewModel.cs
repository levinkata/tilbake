using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class ResidenceTypesViewModel
    {
        public IEnumerable<ResidenceType> ResidenceTypes { get; set; }
    }
}