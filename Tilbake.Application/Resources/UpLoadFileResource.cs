using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Core.Enums;

namespace Tilbake.Application.Resources
{
    public class UpLoadFileResource
    {
        public Guid PortfolioId { get; set; }

        [Display(Name = "File")]
        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        public IFormFile UpLoadFile { get; set; }

        [Display(Name = "File Template")]
        public Guid FileTemplateId { get; set; }

        [Display(Name = "File Type")]
        public FileType FileType { get; set; }

        [Display(Name = "Delimter")]
        public string Delimiter { get; set; }

        [Display(Name = "Table")]
        public string TableName { get; set; }

        [Display(Name = "Starting Row")]
        public int StartRow { get; set; }

        //  Descriptions
        public string PortfolioName { get; set; }
    }
}
