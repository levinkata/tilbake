using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class InsurersViewModel
    {
        public IEnumerable<Insurer> Insurers { get; set; }
    }
}
