using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class SalesTypesViewModel
    {
        public IEnumerable<SalesType> SalesTypes { get; set; }
    }
}
