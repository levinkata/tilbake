using Microsoft.AspNetCore.Mvc.Rendering;
using Tilbake.Domain.Enums;

namespace Tilbake.Application.Resources
{
    public class SelectedTableResource
    {
        public Guid PortfolioId { get; set; }
        public Guid FileTemplateId { get; set; }
        public FileFormat FileFormat { get; set; }
        public string TableName { get; set; }
        public SelectList TableList { get; set; }
    }
}
