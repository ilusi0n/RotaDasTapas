using System;
using System.Linq;
using FluentValidation;
using RotaDasTapas.Constants;
using RotaDasTapas.Models.Request;
using RotaDasTapas.Utils;

namespace RotaDasTapas.Validators
{
    public class JourneyParametersValidator  : AbstractValidator<JourneyParameters>
    {
        public JourneyParametersValidator()
        {
            RuleFor(s => s.Localtime)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(CheckValidDate).WithMessage(ErrorConstants.InvalidDatetime);
            RuleFor(s => s.City)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(CheckCountry).WithMessage(ErrorConstants.InvalidCountry);
            RuleFor(s => s.ListSelectedTapas)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(CheckList).WithMessage(ErrorConstants.InvalidListFormat)
                .Must(CheckLengthList).WithMessage(ErrorConstants.InvalidLengthJourney);
        }

        private bool CheckCountry(string city)
        {
            var list = TapasUtils.InitMock();
            return list.ToList().Exists(s => s.City.Equals(city));
        }

        private bool CheckList(string list)
        {
            return list.Split(Separators.Pipe).Length>1;
        }

        private bool CheckLengthList(string list)
        {
            return list.Split(Separators.Pipe).Length > 2;
        }
        
        private bool CheckValidDate(string value)
        {
            return DateTime.TryParse(value,out _);
        }
    }
}