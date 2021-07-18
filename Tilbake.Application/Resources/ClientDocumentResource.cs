using System;

namespace Tilbake.Application.Resources
{
    public class ClientDocumentResource
    {
        public Guid Id { get; set; }
        public int ClaimNumber { get; set; }
        public string Name { get; set; }
        public Guid DocumentTypeId { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string DocumentPath { get; set; }
    }
}