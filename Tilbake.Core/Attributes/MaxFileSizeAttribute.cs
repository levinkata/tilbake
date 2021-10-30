using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Core.Attributes
{
    public sealed class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(
                                object value, ValidationContext validationContext)
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
            return $"Maximum allowed file size is { _maxFileSize} bytes.";
        }
    }
}
