using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tilbake.Application.Resources
{
    public class RatingMotorSelectResource
    {
        public Guid InsurerId { get; set; }

        public SelectList InsurerList { get; set; }
    }
}