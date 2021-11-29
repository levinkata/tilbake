using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class RelationTypeRepository : Repository<RelationType>, IRelationTypeRepository
    {
        public RelationTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}