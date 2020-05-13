using System;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class MotorViewModel
    {
        public Guid KlientID { get; set; }
        public Motor Motor { get; set; }
    }
}
