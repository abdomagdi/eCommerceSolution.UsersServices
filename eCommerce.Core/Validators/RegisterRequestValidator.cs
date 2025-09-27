using eCommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators
{
    public class RegisterRequestValidator:AbstractValidator<RegisterationRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("Person Name is required")
                .Length(1, 50).WithMessage("Should be between 1 and 50 characters long");
            RuleFor(x => x.Gender).IsInEnum().WithMessage("Must be a valid enum value (Male, Female)");


        }
    }
}
