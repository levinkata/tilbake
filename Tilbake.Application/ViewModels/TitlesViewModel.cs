using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class TitlesViewModel
    {
        public IEnumerable<Title> Titles {get; set; }
    }
}