using System;

namespace Tilbake.Domain.Models.Common
{
    public abstract class AuditableModel
    {
        public Guid? AddedBy { get; set; }
        public DateTime DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; } 
    }
}