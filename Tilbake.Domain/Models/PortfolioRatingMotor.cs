﻿using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class PortfolioRatingMotor
    {
        public Guid PortfolioId { get; set; }
        public Guid RatingMotorId { get; set; }
        public Guid? AddedById { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Portfolio Portfolio { get; set; }
        public virtual RatingMotor RatingMotor { get; set; }
    }
}
