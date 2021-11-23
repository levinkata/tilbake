using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class FileTemplateRecordViewModel
    {
        public Guid Id { get; set; }
        public Guid FileTemplateId { get; set; }

        [Display(Name = "Table Name")]
        public string TableName { get; set; }

        [Display(Name = "Table Label")]
        public string TableLabel { get; set; }

        [Display(Name = "Field Name")]
        public string FieldName { get; set; }
        
        [Display(Name = "Field Label")]
        public string FieldLabel { get; set; }

        [Display(Name = "Position")]
        public string Position { get; set; }

        [Display(Name = "Length")]
        public int ColumnLength { get; set; }

        [Display(Name = "Is Key")]
        public bool IsKey { get; set; }

        //  Description
        public string FileTemplateName { get; set; }
    }
}