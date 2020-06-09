using System;
using FluentValidation;
using RotaDasTapas.Constants;
using RotaDasTapas.Models.Request;

namespace RotaDasTapas.Validators
{
    public class TapasParametersValidator : AbstractValidator<TapasParameters>
    {
        public TapasParametersValidator()
        {
            RuleFor(s => s.Localtime)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(CheckValidDate).WithMessage(ErrorConstants.InvalidDatetime);
        }

        private bool CheckValidDate(string value)
        {
            return DateTime.TryParse(value, out _);
        }
    }
}