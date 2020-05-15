using System;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class HouseViewModel
    {
        public Guid KlientID { get; set; }
        public House House { get; set; }
    }
}
