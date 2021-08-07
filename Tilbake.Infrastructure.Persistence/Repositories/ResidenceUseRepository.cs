﻿using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class ResidenceUseRepository : Repository<ResidenceUse>, IResidenceUseRepository
    {
        public ResidenceUseRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
