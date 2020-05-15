using System;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class GlassViewModel
    {
        public Guid KlientID { get; set; }
        public Glass Glass { get; set; }
    }
}
