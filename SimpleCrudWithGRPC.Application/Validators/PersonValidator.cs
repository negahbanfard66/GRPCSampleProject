using FluentValidation;
using SimpleCrudWithGRPC.Application.DTOs;

namespace SimpleCrudWithGRPC.Application.Validators
{
    public class PersonValidator : AbstractValidator<PersonDto>
    {
        public PersonValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.NationalCode).NotEmpty().Length(10);
            RuleFor(x => x.DateOfBirth).NotEmpty();
        }
    }
}
