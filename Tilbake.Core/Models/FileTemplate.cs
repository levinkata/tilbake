using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class FileTemplate
{
    public Guid Id { get; set; }

    public Guid PortfolioId { get; set; }

    public string Name { get; set; } = null!;

    public string FileType { get; set; } = null!;

    public string? Delimiter { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<FileTemplateRecord> FileTemplateRecords { get; set; } = new List<FileTemplateRecord>();

    public virtual Portfolio Portfolio { get; set; } = null!;
}
