using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class FileTemplateRecord
    {
        public Guid Id { get; set; }
        public Guid FileTemplateId { get; set; }
        public string TableName { get; set; }
        public string TableLabel { get; set; }
        public string FieldName { get; set; }
        public string FieldLabel { get; set; }
        public string Position { get; set; }
        public int ColumnLength { get; set; }
        public bool IsKey { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual FileTemplate FileTemplate { get; set; }
    }
}
