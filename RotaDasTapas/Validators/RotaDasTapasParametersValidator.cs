using System;
using FluentValidation;
using RotaDasTapas.Models.Request;

namespace RotaDasTapas.Validators
{
    public class RotaDasTapasParametersValidator: AbstractValidator<RotaDasTapasParameters>
    {
        public RotaDasTapasParametersValidator()
        {
            RuleFor(s => s.Localtime)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(CheckValidDate).WithMessage("DateTime provided is not valid");
        }

        private bool CheckValidDate(string value)
        {
            return DateTime.TryParse(value,out _);
        }
    }
}