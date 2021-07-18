using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Tilbake.Application.ValidationAttributes
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }
        protected override ValidationResult IsValid (object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult(GetMaxErrorMessage());
                }
            }
            return ValidationResult.Success;
        }

        public string GetMaxErrorMessage()
        {
            return $"Maximum allowed file size is {_maxFileSize} bytes.";
        }
    }
}