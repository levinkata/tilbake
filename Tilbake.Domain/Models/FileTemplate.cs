using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class FileTemplate
    {
        public FileTemplate()
        {
            FileTemplateRecords = new HashSet<FileTemplateRecord>();
        }

        public Guid Id { get; set; }
        public Guid PortfolioId { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public string Delimiter { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Portfolio Portfolio { get; set; }
        public virtual ICollection<FileTemplateRecord> FileTemplateRecords { get; set; }
    }
}
