using System;

namespace Tilbake.Core.Models.Common
{
    public interface IAuditEntity
    {
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
