using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class FileTemplateRecord
    {
        public Guid Id { get; set; }
        public Guid FileTemplateId { get; set; }
        public string TableName { get; set; } = null!;
        public string TableLabel { get; set; } = null!;
        public string FieldName { get; set; } = null!;
        public string FieldLabel { get; set; } = null!;
        public string? Position { get; set; }
        public int ColumnLength { get; set; }
        public bool IsKey { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual FileTemplate FileTemplate { get; set; } = null!;
    }
}
