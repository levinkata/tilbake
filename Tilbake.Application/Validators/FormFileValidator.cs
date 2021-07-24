using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Tilbake.Application.Validators
{
    public class FormFileValidator : AbstractValidator<IFormFile>
    {
        public FormFileValidator()
        {
            RuleFor(p => p.Length)
                    .NotNull()
                    .LessThanOrEqualTo(10240)
                    .WithMessage("File size is larger than allowed");

            RuleFor(p => p.ContentType)
                    .NotNull()
                    .Must(p => p.Equals("image/jpeg") || p.Equals("image/jpg") || p.Equals("image/png"))
                    .WithMessage("File type is larger than allowed");
        }
    }
}