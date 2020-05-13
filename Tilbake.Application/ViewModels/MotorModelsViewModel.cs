using System;
using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class MotorModelsViewModel
    {
        public Guid MotorMakeID { get; set; }
        public IEnumerable<MotorModel> MotorModels { get; set; }
    }
}
