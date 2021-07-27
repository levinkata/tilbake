using System;

namespace Tilbake.Domain.Models.Common
{
    public interface IAuditEntity
    {
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
