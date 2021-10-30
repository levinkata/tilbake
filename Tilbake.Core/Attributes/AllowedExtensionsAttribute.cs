using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Tilbake.Core.Attributes
{
    public sealed class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _Extensions;
        private readonly CultureInfo culture = CultureInfo.CurrentCulture;

        public AllowedExtensionsAttribute(string[] Extensions)
        {
            _Extensions = Extensions;
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException(nameof(validationContext));
            };


            if (!(value is IFormFile file))
            {
                throw new ArgumentNullException(nameof(value));
            }
            else
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_Extensions.Contains(extension.ToLower(culture)))
                {
                    return new ValidationResult(GetAllowedErrorMessage());
                }
            };
            return ValidationResult.Success;
        }

        public static string GetAllowedErrorMessage()
        {
            return $"This photo extension is not allowed!";
        }
    }
}
