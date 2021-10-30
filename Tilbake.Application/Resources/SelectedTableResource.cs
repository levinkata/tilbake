using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Tilbake.Core.Enums;

namespace Tilbake.Application.Resources
{
    public class SelectedTableResource
    {
        public Guid PortfolioId { get; set; }
        public Guid FileTemplateId { get; set; }
        public FileType FileType { get; set; }
        public string TableName { get; set; }
        public SelectList TableList { get; set; }
    }
}
